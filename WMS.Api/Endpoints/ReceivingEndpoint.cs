using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class ReceivingEndpoint
{
    const string GetReceivingEndpoint = "GetReceiving";
    public static RouteGroupBuilder MapReceivingEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("receiving").WithParameterValidation();

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

        group.MapGet("/v2", async (
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;

            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Receivings
                .AsNoTracking()
                .Include(receiving => receiving.Products)
                    .ThenInclude(receivedProduct => receivedProduct.Product)
                .Include(receiving => receiving.Products)
                    .ThenInclude(receivedProduct => receivedProduct.Pallet)
                .Include(receiving => receiving.Warehouse);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(receiving => receiving.Id)
                .Select(receiving => receiving.ToReceivingSummaryDto())
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<ReceivingSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(
                    totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<ReceivingSummaryDto>>(StatusCodes.Status200OK); 

        group.MapGet("/warehouse/{WarehouseId}", async (int WarehouseId, WMSContext dbContext) =>
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

        group.MapGet("/{id}", async (int id, WMSContext dbContext) =>
        {
            Receiving? receiving = await dbContext.Receivings.Include(receiving => receiving.Products!).ThenInclude(product => product!.Product).FirstOrDefaultAsync(result => result.Id == id);

            return receiving is null ? Results.NotFound() : Results.Ok(receiving.ToReceivingDetailsDto());
        }).WithName(GetReceivingEndpoint);

        group.MapPost("/", async (CreateReceivingDto NewReceiving, WMSContext dbContext) =>
        {
            Receiving receiving = NewReceiving.ToEntity();
            dbContext.Receivings.Add(receiving);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetReceivingEndpoint, new { id = receiving.Id }, receiving.ToReceivingDetailsDto());
        });

        group.MapPut("/{id}", async (int id, WMSContext dbContext, CreateReceivingDto updatedReceiving) =>
        {
            var existingReceiving = await dbContext.Receivings.Include(receiving => receiving.Products!).ThenInclude(product => product!.Product).FirstOrDefaultAsync(result => result.Id == id);
            if (existingReceiving is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingReceiving).CurrentValues.SetValues(updatedReceiving.ToUpdateEntity(id));

            // Update the related entities (ReceivedProducts)
            foreach (var updatedProduct in updatedReceiving.Products)
            {
                var existingProduct = existingReceiving.Products.FirstOrDefault(p => p.Id == updatedProduct.Id && p.ProductId == updatedProduct.ProductId);
                if (existingProduct != null && existingProduct.Id != 0)
                {
                    // Update existing product properties
                    dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
                }
                else
                {
                    // If the product doesn't exist, you might want to add it
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

            // Optionally remove any products that are not in the updatedReceiving
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

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            var existingReceiving = await dbContext.Receivings
                .Include(receiving => receiving.Products)
                .FirstOrDefaultAsync(receiving => receiving.Id == id);

            if (existingReceiving is null)
            {
                return Results.NotFound();
            }

            // Remove related ReceivedProducts
            dbContext.ReceivedProducts.RemoveRange(existingReceiving.Products);

            // Remove the receiving record
            dbContext.Receivings.Remove(existingReceiving);

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });
        
        return group;
    }
}
