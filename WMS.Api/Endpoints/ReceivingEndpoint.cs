using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Hubs;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class ReceivingEndpoint
{
    const string GetReceivingEndpoint = "GetReceiving";

    public static RouteGroupBuilder MapReceivingEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("receiving").WithTags("Receiving").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Receivings
                   .Include(receiving => receiving.Products)
                        .ThenInclude(receivedProduct => receivedProduct.Product)
                   .Include(receiving => receiving.Products)
                        .ThenInclude(receivedProduct => receivedProduct.Pallet)
                   .Include(receiving => receiving.Warehouse)
                  .Select(receiving => receiving.ToReceivingSummaryDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2", async (
            WMSContext dbContext,
            string? search = null,
            int? warehouseId = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;

            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Receivings
                .Include(receiving => receiving.Products)
                    .ThenInclude(receivedProduct => receivedProduct.Product)
                .Include(receiving => receiving.Products)
                    .ThenInclude(receivedProduct => receivedProduct.Pallet)
                .Include(receiving => receiving.Warehouse)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(receiving => receiving.WarehouseId == warehouseId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(receiving =>
                    receiving.Series.Contains(search) ||
                    (receiving.Warehouse != null && receiving.Warehouse.Name.Contains(search)) ||
                    (receiving.Shipper != null && receiving.Shipper.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            // Fetch entities from MySQL first
            var receivings = await query
                .OrderByDescending(receiving => receiving.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            // Map to DTOs in C# memory
            var items = receivings
                .Select(receiving => receiving.ToReceivingSummaryDto())
                .ToList();

            var response = new PaginatedResponse<ReceivingSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ReceivingSummaryDto>>(StatusCodes.Status200OK);

        group.MapGet("/shippers", async (
            WMSContext dbContext,
            int? warehouseId = null,
            CancellationToken cancellationToken = default) =>
                {
                    var query = dbContext.Receivings
                        .AsNoTracking()
                        .Where(r => !string.IsNullOrWhiteSpace(r.Shipper));

                    if (warehouseId.HasValue)
                    {
                        query = query.Where(r => r.WarehouseId == warehouseId.Value);
                    }

                    var shippers = await query
                        .Select(r => r.Shipper!.Trim())
                        .Distinct()
                        .OrderBy(s => s)
                        .ToListAsync(cancellationToken);

                    return Results.Ok(shippers);
                })
        .WithName("GetAllShippersFromReceiving")
        .WithSummary("Get all unique shippers from receiving receipts")
        .WithDescription("Retrieves a distinct list of non-empty shipper names across all receiving records, sorted alphabetically.")
        .Produces<List<string>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /warehouse/{WarehouseId} (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/warehouse/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
            await dbContext.Receivings
                    .Where(receiving => receiving.WarehouseId == WarehouseId)
                   .Include(receiving => receiving.Products)
                        .ThenInclude(receivedProduct => receivedProduct.Product)
                   .Include(receiving => receiving.Products)
                        .ThenInclude(receivedProduct => receivedProduct.Pallet)
                   .Include(receiving => receiving.Warehouse)
                  .Select(receiving => receiving.ToReceivingSummaryDto())
                  .AsNoTracking()
                  .ToListAsync()
        );

        // -----------------------------------------------------------------------------
        // Helper & Single Item Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/series", async (WMSContext dbContext) =>
        {
            var twoDigitYear = DateTime.Now.ToString("yy");
            var lastSeries = await dbContext.Receivings
                                 .Where(s => s.Series.StartsWith("SLCWH-") && s.Series.EndsWith($"-{twoDigitYear}"))
                                 .OrderByDescending(s => s.Series)
                                 .Select(s => s.Series)
                                 .FirstOrDefaultAsync();

            return lastSeries is null ? Results.Ok("No series found") : Results.Ok(lastSeries);
        });

        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Receiving? receiving = await dbContext.Receivings
                .Include(receiving => receiving.Products!)
                    .ThenInclude(product => product!.Product)
                .FirstOrDefaultAsync(result => result.Id == id);

            return receiving is null ? Results.NotFound() : Results.Ok(receiving.ToReceivingDetailsDto());
        }).WithName(GetReceivingEndpoint);

        // -----------------------------------------------------------------------------
        // Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (
            CreateReceivingDto newReceivingDto,
            WMSContext dbContext,
            IHubContext<NotificationHub, INotificationClient> hubContext,
            CancellationToken cancellationToken) =>
        {
            // 1. Mandatory Incoming Record Lookup & Validation
            var incoming = await dbContext.Incomings
                .Include(inc => inc.Products)
                .FirstOrDefaultAsync(inc => inc.Id == newReceivingDto.IncomingId, cancellationToken);

            if (incoming is null)
            {
                return Results.NotFound(new { Message = $"Incoming shipment record #{newReceivingDto.IncomingId} was not found." });
            }

            // Prevent receiving an incoming record that was already fully processed
            if (incoming.Status == IncomingStatus.RECEIVED)
            {
                return Results.BadRequest(new { Message = $"Incoming shipment #{incoming.Id} has already been fully received." });
            }

            // 2. Identify received Product IDs from payload & update IncomingProduct flags
            var receivedProductIds = newReceivingDto.Products
                .Select(p => p.ProductId)
                .Distinct()
                .ToHashSet();

            foreach (var incProduct in incoming.Products)
            {
                if (receivedProductIds.Contains(incProduct.ProductId))
                {
                    incProduct.Received = true;
                }
            }

            // 3. Calculate overall Incoming status (RECEIVED if all products received, otherwise PARTIAL)
            if (incoming.Products.Count > 0 && incoming.Products.All(p => p.Received))
            {
                incoming.Status = IncomingStatus.RECEIVED;
            }
            else if (incoming.Products.Any(p => p.Received))
            {
                incoming.Status = IncomingStatus.PARTIAL;
            }

            // 4. Convert DTO to Receiving entity (maps expected vs actual line-item details)
            Receiving receiving = newReceivingDto.ToEntity();
            dbContext.Receivings.Add(receiving);

            // 5. Save changes in a single atomic transaction
            await dbContext.SaveChangesAsync(cancellationToken);

            // 6. SignalR Real-time Notification
            await hubContext.Clients.All.ReceivingCreated();

            return Results.CreatedAtRoute(
                GetReceivingEndpoint,
                new { id = receiving.Id },
                receiving.ToReceivingDetailsDto());
        })
        .WithName("CreateReceiving")
        .WithSummary("Create a new receiving receipt")
        .WithDescription("Creates a receiving receipt linked to an Incoming shipment, marks specific line items as received, and sets Incoming status to PARTIAL or RECEIVED.")
        .Produces<ReceivingDetailsDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound);

        group.MapPut("/{id:int}", async (int id, WMSContext dbContext, CreateReceivingDto updatedReceiving) =>
        {
            var existingReceiving = await dbContext.Receivings
                .Include(receiving => receiving.Products!)
                    .ThenInclude(product => product!.Product)
                .FirstOrDefaultAsync(result => result.Id == id);

            if (existingReceiving is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingReceiving).CurrentValues.SetValues(updatedReceiving.ToUpdateEntity(id));

            // Update related entities (ReceivedProducts)
            foreach (var updatedProduct in updatedReceiving.Products)
            {
                var existingProduct = existingReceiving.Products.FirstOrDefault(p => p.Id == updatedProduct.Id && p.ProductId == updatedProduct.ProductId);
                if (existingProduct != null && existingProduct.Id != 0)
                {
                    dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
                }
                else
                {
                    existingReceiving.Products.Add(new ReceivedProduct
                    {
                        ProductId = updatedProduct.ProductId,
                        Quantity = updatedProduct.Quantity,
                        CBM = updatedProduct.CBM,
                        TotalWeight = updatedProduct.TotalWeight,
                        Remarks = updatedProduct.Remarks,
                        ExpirationDate = updatedProduct.ExpirationDate,
                        ContainerName = updatedProduct.ContainerName,
                        PalletId = updatedProduct.PalletId
                    });
                }
            }

            foreach (var existingProduct in existingReceiving.Products.ToList())
            {
                if (!updatedReceiving.Products.Any(p => p.Id == existingProduct.Id && p.ProductId == existingProduct.ProductId))
                {
                    dbContext.ReceivedProducts.Remove(existingProduct);
                }
            }

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            var existingReceiving = await dbContext.Receivings
                .Include(receiving => receiving.Products)
                .FirstOrDefaultAsync(receiving => receiving.Id == id);

            if (existingReceiving is null)
            {
                return Results.NotFound();
            }

            dbContext.ReceivedProducts.RemoveRange(existingReceiving.Products);
            dbContext.Receivings.Remove(existingReceiving);

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}