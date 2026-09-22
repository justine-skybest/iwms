using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Bin;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Mapping;

namespace WMS.Api.Endpoints;

public static class BinEndpoint
{
    const string GetBinEndpointName = "GetBin";

    public static RouteGroupBuilder MapBinEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("bin").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext) =>
            await dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Select(bin => bin.ToSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapGet("/v2", async (
            WMSContext dbContext,
            int page = 1,
            int? warehouseId = null,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(bi => bi.Rack!.WarehouseId == warehouseId.Value);
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bin => bin.ToSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /AvailableBin/{WarehouseId} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/AvailableBin/{WarehouseId:int}", async (WMSContext dbContext, int WarehouseId) =>
            await dbContext.Bins
                    .Include(bin => bin.Rack)
                        .ThenInclude(rack => rack!.Warehouse)
                    .Include(bin => bin.Bay)
                    .Include(bin => bin.Level)
                    .Include(bin => bin.BinNames)
                    .Where(bin => bin.Rack!.WarehouseId == WarehouseId)
                    .Where(bin => !dbContext.CheckIns
                            .Any(checkIn => checkIn.Bins.Any(b => b.Id == bin.Id)))
                    .OrderBy(bin => bin.Rack!.Warehouse)
                        .ThenBy(bin => bin.Rack)
                        .ThenBy(bin => bin.Bay)
                        .ThenBy(bin => bin.Level)
                        .ThenBy(bin => bin.BinNames)
                    .Select(bin => bin.ToDetailsDto())
                    .AsNoTracking()
                    .ToListAsync() ?? []
        );

        group.MapGet("/v2/AvailableBin/{WarehouseId:int}", async (
            int WarehouseId,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.Rack!.WarehouseId == WarehouseId)
                .Where(bin => !dbContext.CheckIns.Any(checkIn => checkIn.Bins.Any(b => b.Id == bin.Id)))
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bin => bin.ToDetailsDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinDetailsDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinDetailsDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /CheckedIn & /QRCode
        // -----------------------------------------------------------------------------
        group.MapGet("CheckedIn/{BinHashCode:int}/{WarehouseId:int}", async (int BinHashCode, int WarehouseId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins
            .Where(b => b.BinHashCode == BinHashCode && b.Rack!.WarehouseId == WarehouseId)
            .Include(b => b.Rack)
                .ThenInclude(r => r!.Warehouse)
            .Include(b => b.Bay)
            .Include(b => b.Level)
            .Include(b => b.BinNames)
            .Include(b => b.CheckIns)
                .ThenInclude(ci => ci.ReceivedProducts)
            .Include(b => b.CheckIns)
                .ThenInclude(ci => ci.Pallet)
                    .ThenInclude(p => p!.ReceivedProducts)
            .FirstOrDefaultAsync();

            if (bin == null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.Now));
            }

            if (!bin.CheckIns.Any())
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently empty.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.Now));
            }

            // Check if any ReceivedProduct in this bin has remaining unpicked quantity
            bool anyUnpicked = false;
            foreach (var checkIn in bin.CheckIns)
            {
                var products = (checkIn.Pallet?.ReceivedProducts != null && checkIn.Pallet.ReceivedProducts.Any())
                    ? checkIn.Pallet.ReceivedProducts
                    : checkIn.ReceivedProducts;

                foreach (var received in products)
                {
                    // Query picked quantity directly by ReceivedProductId (ignores previous check-in IDs)
                    var totalPicked = await dbContext.PickedProducts
                        .Where(p => p.ReceivedProductId == received.Id)
                        .SumAsync(p => (int?)p.QuantityPicked) ?? 0;

                    if (totalPicked < received.Quantity)
                    {
                        anyUnpicked = true;
                        break;
                    }
                }
                if (anyUnpicked) break;
            }

            if (!anyUnpicked)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently empty.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.Now));
            }

            return Results.Ok(bin.ToSummaryDto());
        })
        .WithName("GetCheckedInBinByQrCode")
        .WithSummary("Locate Checked-In Bin by QR Code")
        .WithDescription("Scans a bin QR HashCode and returns bin details if it currently contains unpicked stock.")
        .Produces<BinSummaryDto>(StatusCodes.Status200OK);

        group.MapGet("/QRCode/{binHashCode:int}/{warehouseId:int}", async (
            int binHashCode,
            int warehouseId,
            WMSContext dbContext,
            CancellationToken cancellationToken = default) =>
        {
            var bin = await dbContext.Bins
                .AsNoTracking()
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .FirstOrDefaultAsync(b => b.BinHashCode == binHashCode && b.Rack!.WarehouseId == warehouseId, cancellationToken);

            if (bin is null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow
                ));
            }

            bool binIsInUse = await dbContext.CheckIns
                .AsNoTracking()
                .Where(checkIn => checkIn.Bins.Any(b => b.Id == bin.Id))
                .AnyAsync(checkIn =>
                    checkIn.ReceivedProducts.Any(received =>
                        dbContext.PickedProducts
                            .Where(p => p.ReceivedProductId == received.Id)
                            .Sum(p => p.QuantityPicked) < received.Quantity
                    ), cancellationToken);

            if (binIsInUse)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently in use.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow
                ));
            }

            return Results.Ok(bin.ToSummaryDto());
        })
        .Produces<BinSummaryDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /rack/{id} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/rack/{id}", async (int id, WMSContext dbContext) =>
           await dbContext.Bins
               .Include(bin => bin.Rack)
                   .ThenInclude(rack => rack!.Warehouse)
               .Include(bin => bin.Bay)
               .Include(bin => bin.Level)
               .Include(bin => bin.BinNames)
               .Where(bin => bin.RackId == id)
               .OrderBy(bin => bin.Rack!.Warehouse)
                   .ThenBy(bin => bin.Rack)
                   .ThenBy(bin => bin.Bay)
                   .ThenBy(bin => bin.Level)
                   .ThenBy(bin => bin.BinNames)
               .Select(bin => bin.ToSummaryDto())
               .AsNoTracking()
               .ToListAsync()
        ).Produces<BinSummaryDto>(StatusCodes.Status200OK);

        group.MapGet("/v2/rack/{id}", async (
            int id,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.RackId == id)
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bin => bin.ToSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // GET /rack/{rackId}/bay/{bayId} (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/rack/{rackId}/bay/{bayId}", async (int rackId, int bayId, WMSContext dbContext) =>
            await dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.RackId == rackId && bin.BayId == bayId)
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Select(bin => bin.ToSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        group.MapGet("/v2/rack/{rackId}/bay/{bayId}", async (
            int rackId,
            int bayId,
            WMSContext dbContext,
            int page = 1,
            int pageSize = 50,
            CancellationToken cancellationToken = default) =>
        {
            const int maxPageSize = 500;
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, maxPageSize);

            var query = dbContext.Bins
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.RackId == rackId && bin.BayId == bayId)
                .AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(bin => bin.ToSummaryDto())
                .ToListAsync(cancellationToken);

            var response = new PaginatedResponse<BinSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return Results.Ok(response);
        })
        .Produces<PaginatedResponse<BinSummaryDto>>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Standard Single Item & Operation Routes
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Bin? bin = await dbContext.Bins.FindAsync(id);

            return bin is null ? Results.NotFound() : Results.Ok(bin.ToDetailsDto());
        })
        .WithName(GetBinEndpointName)
        .WithSummary("Get bin details by ID")
        .WithDescription("Retrieves the structural configuration and metadata of a specific bin location using its primary key ID.")
        .Produces<BinDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/hashcode/{hashCode:int}/{warehouseId:int}", async (int hashCode, int warehouseId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins
                .Where(b => b.BinHashCode == hashCode && b.Rack!.WarehouseId == warehouseId)
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return bin is null
                ? Results.NotFound($"Bin with Hash Code #{hashCode} not found in this warehouse.")
                : Results.Ok(bin.ToSummaryDto());
        })
        .WithName("GetBinByHashCode")
        .WithSummary("Get bin details by QR code hash")
        .WithDescription("Retrieves the structural configuration and metadata of a specific bin location by filtering first on its QR code hash code and warehouse ID.")
        .Produces<BinSummaryDto>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // Stock Query (Fixed: Query picks by ReceivedProductId directly)
        // -----------------------------------------------------------------------------
        group.MapGet("/stock/id/{BinId:int}", async (int BinId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins.FindAsync(BinId);
            if (bin == null)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == BinId))
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
                .ToListAsync();

            if (!checkIns.Any())
                return Results.Ok(new List<DisplayCheckInProductsDto>());

            // Collect all unique ReceivedProduct IDs across target check-ins/pallets
            var receivedProductIds = checkIns
                .SelectMany(ci => (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Any())
                    ? ci.Pallet.ReceivedProducts
                    : ci.ReceivedProducts)
                .Select(rp => rp.Id)
                .Distinct()
                .ToList();

            // Query picked totals by ReceivedProductId to maintain history across transfers
            var pickedMap = await dbContext.PickedProducts
                .Where(pp => receivedProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => pp.ReceivedProductId)
                .ToDictionaryAsync(g => g.Key, g => g.Sum(pp => pp.QuantityPicked));

            var result = checkIns.Select(ci =>
            {
                var targetProducts = (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Any())
                    ? ci.Pallet.ReceivedProducts
                    : ci.ReceivedProducts;

                var mappedProducts = targetProducts
                    .Select(rp =>
                    {
                        var pickedQty = pickedMap.TryGetValue(rp.Id, out var qty) ? qty : 0;
                        var availableQty = rp.Quantity - pickedQty;

                        return new CheckedInProductSumamryDto(
                            id: rp.Id,
                            Name: rp.Product?.Name ?? "",
                            TypeOfPackage: rp.Product?.TypeOfPackage ?? "",
                            Measurement: rp.Product?.Measurement ?? "",
                            Weight: rp.Product?.Weight ?? 0,
                            Quantity: availableQty,
                            CBM: rp.CBM,
                            TotalWeight: rp.TotalWeight,
                            ExpirationDate: rp.ExpirationDate,
                            Remarks: rp.Remarks,
                            ContainerName: rp.ContainerName,
                            PalletId: rp.PalletId?.ToString() ?? ci.PalletId?.ToString(),
                            ReceivingSeries: rp.Receiving?.Series,
                            Shipper: rp.Receiving?.Shipper
                        );
                    })
                    .Where(rp => rp.Quantity > 0)
                    .ToList();

                return new DisplayCheckInProductsDto(
                    Id: ci.Id,
                    CheckInType: ci.CheckInType,
                    PalletNumber: ci.Pallet?.PalletNumber != null ? "Pallet #" + ci.Pallet.PalletNumber : "",
                    ReceivedProducts: mappedProducts,
                    CheckInDate: ci.CheckInDate,
                    Notes: ci.Notes
                );
            })
            .Where(dto => dto.ReceivedProducts.Any())
            .ToList();

            return Results.Ok(result);
        })
        .WithName("GetBinStockById")
        .WithSummary("Get available stock in a specific bin by ID")
        .WithDescription("Retrieves active check-ins for a given bin ID, prioritizing palletized received products and calculating net unpicked stock across transfers.")
        .Produces<List<DisplayCheckInProductsDto>>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

        group.MapGet("/history/{BinId}", async (int BinId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins.FindAsync(BinId);
            if (bin == null)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == BinId))
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Receiving)
                .Include(ci => ci.Pallet)
                .ToListAsync();

            var checkInIds = checkIns.Select(ci => ci.Id).ToList();

            var manualPickings = await dbContext.ManualPickings
                .Where(mp => mp.CheckInId != null && checkInIds.Contains(mp.CheckInId.Value))
                .Include(mp => mp.CheckIn)
                .Include(mp => mp.PickedProducts)
                    .ThenInclude(pp => pp.ReceivedProduct)
                        .ThenInclude(rp => rp!.Product)
                .Include(mp => mp.PickedProducts)
                    .ThenInclude(pp => pp.ReceivedProduct)
                        .ThenInclude(rp => rp!.Receiving)
                .OrderBy(mp => mp.PickingDate)
                .ToListAsync();

            var cumulativePicked = new Dictionary<int, int>();

            var inflows = checkIns.Select(ci => ci.ToMovementHistoryDto());
            var outflows = manualPickings.Select(mp => mp.ToMovementHistoryDto(cumulativePicked));

            var history = inflows
                .Concat(outflows)
                .OrderByDescending(m => m.Date)
                .ThenBy(m => m.MovementType == "Checked In" ? 0 : 1)
                .ToList();

            return Results.Ok(history);
        });

        group.MapPost("/", async (CreateBinDto newBin, WMSContext dbContext) =>
        {
            Bin bin = newBin.ToEntity();
            dbContext.Bins.Add(bin);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetBinEndpointName, new { id = bin.Id }, bin.ToDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateBinDto updatedBin, WMSContext dbContext) =>
        {
            var existingBin = await dbContext.Bins.FindAsync(id);
            if (existingBin is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingBin).CurrentValues.SetValues(updatedBin.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, WMSContext dbContext) =>
        {
            await dbContext.Bins.Where(bin => bin.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });

        return group;
    }
}