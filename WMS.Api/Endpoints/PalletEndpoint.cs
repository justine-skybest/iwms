using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Pallet;
using WMS.Api.Entities;
using WMS.Api.Hubs;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class PalletEndpoint
{
    public static RouteGroupBuilder MapPalletEndpoints(this WebApplication app)
    {
        const string GetPalletEndpointName = "GetPallet";
        var group = app.MapGroup("pallet").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
             await dbContext.Pallets
                    .Include(pallet => pallet.Warehouse)
                    .Select(pallet => pallet.ToSummaryDto()).AsNoTracking().ToListAsync() ?? []
        );

        // -----------------------------------------------------------------------------
        // GET /v2?search=&warehouseId=&page=&pageSize=
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

            var query = dbContext.Pallets
                .Include(pallet => pallet.Warehouse)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(pallet => pallet.WarehouseId == warehouseId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                // NOTE: assumes search should match pallet number or warehouse
                // name; adjust to whatever field(s) are actually meaningful
                // for a pallet search (e.g. PalletHashCode).
                query = query.Where(pallet =>
                    pallet.PalletNumber.ToString().Contains(search) ||
                    (pallet.Warehouse != null && pallet.Warehouse.Name.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(pallet => pallet.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(pallet => pallet.ToSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<PalletSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<PalletSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /Warehouse/{id} (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/Warehouse/{id:int}", async (int id, WMSContext dbContext) =>
            await dbContext.Pallets
                    .Include(pallet => pallet.Warehouse)
                    .Where(pallet => pallet.WarehouseId == id)
                    .Select(pallet => pallet.ToSummaryDto()).AsNoTracking().ToListAsync() ?? []
        );

        // -----------------------------------------------------------------------------
        // GET /ToBeCheckIn/{WarehouseId} (v1)
        // -----------------------------------------------------------------------------
        group.MapGet("/ToBeCheckIn/{WarehouseId:int}", async (WMSContext dbContext, int WarehouseId) =>
             await dbContext.Pallets
                    .Include(pallet => pallet.ReceivedProducts!)
                        .ThenInclude(product => product.Product)
                    .Include(pallet => pallet.ReceivedProducts!)
                        .ThenInclude(product => product.Receiving)
                    .Include(pallet => pallet.Warehouse!)
                    .Where(pallet => pallet.ReceivedProducts != null && pallet.ReceivedProducts.Any())
                    .Where(p => !dbContext.CheckIns.Any(c => c.PalletId == p.Id))
                    .Where(pallet => pallet.WarehouseId == WarehouseId)
                    .Select(p => p.ToBeCheckInDto())
                    .AsNoTracking().ToListAsync() ?? []
        );

        // -----------------------------------------------------------------------------
        // GET /v2/ToBeCheckIn/{WarehouseId}?search=&page=&pageSize=
        // -----------------------------------------------------------------------------
        group.MapGet("/v2/ToBeCheckIn/{WarehouseId:int}", async (
            int WarehouseId,
            WMSContext dbContext,
            string? search = null,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Pallets
                .Include(pallet => pallet.ReceivedProducts!)
                    .ThenInclude(product => product.Product)
                .Include(pallet => pallet.ReceivedProducts!)
                    .ThenInclude(product => product.Receiving)
                .Include(pallet => pallet.Warehouse!)
                .Where(pallet => pallet.ReceivedProducts != null && pallet.ReceivedProducts.Any())
                .Where(p => !dbContext.CheckIns.Any(c => c.PalletId == p.Id))
                .Where(pallet => pallet.WarehouseId == WarehouseId)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                // NOTE: matches pallet number or any received product's name.
                // Adjust to whatever field(s) make sense for this view.
                query = query.Where(pallet =>
                    pallet.PalletNumber.ToString().Contains(search) ||
                    pallet.ReceivedProducts!.Any(rp => rp.Product != null && rp.Product.Name.Contains(search)));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(pallet => pallet.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => p.ToBeCheckInDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<PalletToBeCheckInDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<PalletToBeCheckInDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Single Item & Helper Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Pallet? pallet = await dbContext.Pallets.FindAsync(id);

            return pallet is null ? Results.NotFound() : Results.Ok(pallet.ToDetailDto());
        }).WithName(GetPalletEndpointName);

        group.MapGet("/QRCode/{palletHashCode:int}/{warehouseId:int}", async (
        int palletHashCode,
        int warehouseId,
        WMSContext dbContext,
        CancellationToken cancellationToken = default) =>
            {
                var palletData = await dbContext.Pallets
                    .AsNoTracking()
                    .Where(p => p.PalletHashCode == palletHashCode && p.WarehouseId == warehouseId)
                    .Select(p => new
                    {
                        Pallet = p,
                        HasProducts = p.ReceivedProducts.Any()
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (palletData is null)
                {
                    return Results.Ok(new Pallet
                    {
                        Id = 0,
                        WarehouseId = 0,
                        PalletNumber = 0,
                        PalletHashCode = 0,
                        PalletDimension = "This QR code is not present on any pallets in this warehouse."
                    }.ToDetailDto());
                }

                if (palletData.HasProducts)
                {
                    return Results.Ok(new Pallet
                    {
                        Id = 0,
                        WarehouseId = 0,
                        PalletNumber = 0,
                        PalletHashCode = 0,
                        PalletDimension = "This QR code is from a pallet that is currently in use."
                    }.ToDetailDto());
                }

                return Results.Ok(palletData.Pallet.ToDetailDto());
            });

        group.MapGet("/number/{WarehouseId:int}", async (int WarehouseId, WMSContext dbContext) =>
        {
            var lastNumber = await dbContext.Pallets
                                 .OrderByDescending(pallet => pallet.PalletNumber)
                                 .Where(pallet => pallet.WarehouseId == WarehouseId)
                                 .Select(pallet => pallet.PalletNumber)
                                 .FirstOrDefaultAsync();

            return lastNumber;
        });

        // -----------------------------------------------------------------------------
        // Mutation Endpoints
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (CreatePalletDto newPallet, WMSContext dbContext, IHubContext<NotificationHub, INotificationClient> hubContext) =>
        {
            Pallet pallet = newPallet.ToEntity();
            dbContext.Pallets.Add(pallet);
            await dbContext.SaveChangesAsync();

            // Explicitly load the Warehouse navigation property so ToSummaryDto can access Warehouse details
            await dbContext.Entry(pallet).Reference(p => p.Warehouse).LoadAsync();

            await hubContext.Clients.All.PalletCreated();

            return Results.CreatedAtRoute(GetPalletEndpointName, new { id = pallet.Id }, pallet.ToSummaryDto());
        })
        .WithName("CreatePallet")
        .WithSummary("Create a new pallet")
        .WithDescription("Creates a new pallet record in the system and returns its details.")
        .Accepts<CreatePalletDto>("application/json")
        .Produces<PalletSummaryDto>(StatusCodes.Status201Created)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        group.MapPost("/autocreate/{WarehouseId:int}", async (WMSContext dbContext, int WarehouseId, IHubContext<NotificationHub, INotificationClient> hubContext) =>
        {
            var lastNumber = await dbContext.Pallets
                                .OrderByDescending(pallet => pallet.PalletNumber)
                                .Where(pallet => pallet.WarehouseId == WarehouseId)
                                .Select(pallet => pallet.PalletNumber)
                                .FirstOrDefaultAsync();

            var newPalletNumber = lastNumber + 1;

            var hash = new HashCode();
            hash.Add(DateTime.Now);
            hash.Add(DateTime.Now.TimeOfDay);

            var newPallet = new CreatePalletDto(
                WarehouseId,
                newPalletNumber,
                hash.ToHashCode(),
                "",
                0,
                0,
                DateTime.Now
            );

            Pallet pallet = newPallet.ToEntity();
            dbContext.Pallets.Add(pallet);
            await dbContext.SaveChangesAsync();

            await hubContext.Clients.All.PalletCreated();

            return pallet is null ? Results.NoContent() : Results.Ok(pallet.ToDetailDto());
        });

        group.MapPut("/{id}", async (int id, CreatePalletDto updatedPallet, WMSContext dbContext, IHubContext<NotificationHub, INotificationClient> hubContext) =>
        {
            var existingPallet = await dbContext.Pallets.FindAsync(id);
            if (existingPallet is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPallet).CurrentValues.SetValues(updatedPallet.ToUpdateEntity(id));
            await dbContext.SaveChangesAsync();

            await hubContext.Clients.All.PalletUpdated();

            return Results.NoContent();
        })
        .WithName("UpdatePallet")
        .WithSummary("Update an existing pallet")
        .WithDescription("Updates all details of an existing pallet by its ID.")
        .Accepts<CreatePalletDto>("application/json")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Pallets.Where(pallet => pallet.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}