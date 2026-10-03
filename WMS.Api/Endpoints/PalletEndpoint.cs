using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Dtos.Pallet;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Hubs;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class PalletEndpoint
{
    public static RouteGroupBuilder MapPalletEndpoints(this WebApplication app)
    {
        const string GetPalletEndpointName = "GetPallet";

        var group = app.MapGroup("pallet").WithTags("Pallet").WithParameterValidation();

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
        // Get Available Stock by Pallet ID (Supports Unchecked-In Pallets)
        // -----------------------------------------------------------------------------
        group.MapGet("/stock/pallet/{PalletId:int}", async (
            int PalletId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            // 1. Fetch Pallet entity directly with received products
            var pallet = await dbContext.Pallets
                .Include(p => p.ReceivedProducts!)
                    .ThenInclude(rp => rp.Product)
                .Include(p => p.ReceivedProducts!)
                    .ThenInclude(rp => rp.Receiving)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == PalletId, cancellationToken);

            if (pallet is null)
                return Results.NotFound($"Pallet with ID#{PalletId} not found.");

            // 2. Fetch any active CheckIns for this Pallet ID
            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.PalletId == PalletId)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Receiving)
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts!)
                        .ThenInclude(rp => rp.Product)
                .Include(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts!)
                        .ThenInclude(rp => rp.Receiving)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            // 3. Determine target products pool (Check-In vs Unchecked-In Staging)
            List<ReceivedProduct> targetProducts;

            if (checkIns.Any())
            {
                targetProducts = checkIns
                    .SelectMany(ci => (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Any())
                        ? ci.Pallet.ReceivedProducts
                        : ci.ReceivedProducts)
                    .DistinctBy(rp => rp.Id)
                    .ToList();
            }
            else
            {
                targetProducts = pallet.ReceivedProducts?.ToList() ?? new List<ReceivedProduct>();
            }

            var receivedProductIds = targetProducts.Select(rp => rp.Id).Distinct().ToList();

            // 4. Map total picked quantities per ReceivedProductId
            var pickedMap = await dbContext.PickedProducts
                .Where(pp => receivedProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .Select(g => new { ReceivedProductId = g.Key, PickedQty = g.Sum(pp => pp.QuantityPicked) })
                .ToDictionaryAsync(x => x.ReceivedProductId, x => x.PickedQty, cancellationToken);

            // Local product mapping helper
            CheckedInProductSumamryDto MapProduct(ReceivedProduct rp, string? fallbackPalletId)
            {
                var baseQty = rp.ExpectedQuantity is > 0 ? rp.ExpectedQuantity.Value : rp.Quantity;
                var pickedQty = pickedMap.TryGetValue(rp.Id, out var qty) ? qty : 0;
                var availableQty = baseQty - pickedQty;

                return new CheckedInProductSumamryDto(
                    id: rp.Id,
                    Name: rp.Product?.Name ?? rp.ExpectedProductName ?? "",
                    TypeOfPackage: rp.TypeOfPackage ?? rp.Product?.TypeOfPackage ?? "",
                    Measurement: rp.Product?.Measurement ?? "",
                    Weight: rp.Product?.Weight ?? 0,
                    Quantity: availableQty, // Net unpicked stock
                    CBM: rp.CBM,
                    TotalWeight: rp.TotalWeight,
                    ExpirationDate: rp.ExpirationDate ?? rp.ExpectedExpirationDate,
                    Remarks: rp.Remarks,
                    ContainerName: rp.ContainerName,
                    PalletId: rp.PalletId?.ToString() ?? fallbackPalletId,
                    ReceivingSeries: rp.Receiving?.Series,
                    Shipper: rp.Receiving?.Shipper
                );
            }

            List<DisplayCheckInProductsDto> result;

            if (checkIns.Any())
            {
                // Scenario A: Pallet HAS BEEN checked in
                result = checkIns.Select(ci =>
                {
                    var ciTargetProducts = (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Any())
                        ? ci.Pallet.ReceivedProducts
                        : ci.ReceivedProducts;

                    var mappedProducts = ciTargetProducts
                        .Select(rp => MapProduct(rp, ci.PalletId?.ToString()))
                        .Where(rp => rp.Quantity > 0)
                        .ToList();

                    return new DisplayCheckInProductsDto(
                        Id: ci.Id,
                        CheckInType: ci.CheckInType,
                        PalletNumber: ci.Pallet?.PalletNumber != null ? "Pallet #" + ci.Pallet.PalletNumber : $"Pallet #{PalletId}",
                        ReceivedProducts: mappedProducts,
                        CheckInDate: ci.CheckInDate,
                        Notes: ci.Notes
                    );
                })
                .Where(dto => dto.ReceivedProducts != null && dto.ReceivedProducts.Any())
                .ToList();
            }
            else
            {
                // Scenario B: Pallet HAS NOT BEEN checked in yet (Staging / Pending Putaway)
                var mappedProducts = targetProducts
                    .Select(rp => MapProduct(rp, PalletId.ToString()))
                    .Where(rp => rp.Quantity > 0)
                    .ToList();

                if (!mappedProducts.Any())
                {
                    return Results.Ok(new List<DisplayCheckInProductsDto>());
                }

                result = new List<DisplayCheckInProductsDto>
        {
            new DisplayCheckInProductsDto(
                Id: 0,
                CheckInType: "UNCHECKED_IN",
                PalletNumber: pallet.PalletNumber != 0 ? $"Pallet #{pallet.PalletNumber}" : $"Pallet #{PalletId}",
                ReceivedProducts: mappedProducts,
                CheckInDate: null,
                Notes: "Pending Check-In (In Receiving / Staging Area)"
            )
        };
            }

            return Results.Ok(result);
        })
        .WithName("GetPalletStockById")
        .WithSummary("Get available stock for a specific pallet by ID")
        .WithDescription("Retrieves stock for a given Pallet ID, supporting both checked-in bins and unchecked-in staging pallets while calculating net unpicked stock.")
        .Produces<List<DisplayCheckInProductsDto>>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

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