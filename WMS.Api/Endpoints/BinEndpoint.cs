using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos;
using WMS.Api.Dtos.Bin;
using WMS.Api.Dtos.CheckIn;
using WMS.Api.Dtos.Rack;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Entities;
using WMS.Api.Mapping;
using WMS.Api.Services;

namespace WMS.Api.Endpoints;

public static class BinEndpoint
{
    const string GetBinEndpointName = "GetBin";

    public static RouteGroupBuilder MapBinEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("bin").WithTags("Bin").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // GET / (v1 & v2)
        // -----------------------------------------------------------------------------
        group.MapGet("/", async (WMSContext dbContext, CancellationToken ct) =>
        {
            var bins = await dbContext.Bins
                .AsNoTracking()
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .OrderBy(bin => bin.Rack!.Warehouse!.Name ?? bin.Warehouse!.Name ?? string.Empty)
                    .ThenBy(bin => bin.Rack!.Name ?? "Standalone")
                    .ThenBy(bin => bin.Bay!.BayNumber)
                    .ThenBy(bin => bin.Level!.LevelNumber)
                    .ThenBy(bin => bin.BinNames!.BinName ?? string.Empty)
                .ToListAsync(ct);

            var response = bins
                .GroupBy(bin => new
                {
                    RackId = bin.Rack?.Id,
                    RackName = bin.Rack?.Name ?? "Standalone",
                    WarehouseName = bin.Rack?.Warehouse?.Name ?? bin.Warehouse?.Name ?? "N/A"
                })
                .Select(group => new RackGroupDto(
                    group.Key.RackId,
                    group.Key.RackName,
                    group.Key.WarehouseName,
                    group.Select(bin => bin.ToSummaryDto()).ToList()
                ))
                .ToList();

            return TypedResults.Ok(response);
        })
        .WithName("GetBinsGroupedByRack")
        .WithSummary("Get all warehouse bins grouped by rack")
        .Produces<List<RackGroupDto>>(StatusCodes.Status200OK);

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
                .Include(bin => bin.Warehouse)
                .Include(bin => bin.Location3D)
                .AsNoTracking();

            if (warehouseId.HasValue)
            {
                query = query.Where(bi =>
                    bi.WarehouseId == warehouseId.Value ||
                    (bi.Rack != null && bi.Rack.WarehouseId == warehouseId.Value));
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
        // GET /AvailableBin/{WarehouseId} (v1 & v2) - FILTERED BY ACTIVE CHECK-INS
        // -----------------------------------------------------------------------------
        group.MapGet("/AvailableBin/{WarehouseId:int}", async (
            WMSContext dbContext,
            int WarehouseId,
            CancellationToken ct) =>
        {
            var bins = await dbContext.Bins
                .AsNoTracking()
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.Rack!.WarehouseId == WarehouseId || bin.WarehouseId == WarehouseId)
                // Bin is only unavailable if it has an ACTIVE check-in
                .Where(bin => !dbContext.CheckIns.Any(ci => ci.IsActive && ci.Bins.Any(b => b.Id == bin.Id)))
                .OrderBy(bin => bin.Rack!.Warehouse)
                    .ThenBy(bin => bin.Rack)
                    .ThenBy(bin => bin.Bay)
                    .ThenBy(bin => bin.Level)
                    .ThenBy(bin => bin.BinNames)
                .Select(bin => bin.ToDetailsDto())
                .ToListAsync(ct);

            return Results.Ok(bins);
        });

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
                .AsNoTracking()
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Where(bin => bin.Rack!.WarehouseId == WarehouseId || bin.WarehouseId == WarehouseId)
                // Bin is only unavailable if it has an ACTIVE check-in
                .Where(bin => !dbContext.CheckIns.Any(ci => ci.IsActive && ci.Bins.Any(b => b.Id == bin.Id)));

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
        group.MapGet("CheckedIn/{BinHashCode:int}/{WarehouseId:int}", async (
            int BinHashCode,
            int WarehouseId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var bin = await dbContext.Bins
                .AsNoTracking()
                .Where(b => b.BinHashCode == BinHashCode && (b.Rack!.WarehouseId == WarehouseId || b.WarehouseId == WarehouseId))
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                // Filtered include: Load only ACTIVE check-ins
                .Include(b => b.CheckIns.Where(ci => ci.IsActive))
                    .ThenInclude(ci => ci.ReceivedProducts)
                .Include(b => b.CheckIns.Where(ci => ci.IsActive))
                    .ThenInclude(ci => ci.Pallet)
                        .ThenInclude(p => p!.ReceivedProducts)
                .FirstOrDefaultAsync(cancellationToken);

            if (bin == null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow));
            }

            if (!bin.CheckIns.Any())
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently empty.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow));
            }

            // Batch query unpicked quantities to avoid N+1 query loop
            var checkInIds = bin.CheckIns.Select(ci => ci.Id).ToList();
            var allProducts = bin.CheckIns
                .SelectMany(ci => (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Count > 0)
                    ? ci.Pallet.ReceivedProducts
                    : ci.ReceivedProducts)
                .ToList();

            var productIds = allProducts.Select(p => p.Id).Distinct().ToList();

            var pickedMap = await dbContext.PickedProducts
                .AsNoTracking()
                .Where(p => p.ManualPicking != null &&
                            p.ManualPicking.CheckInId.HasValue &&
                            checkInIds.Contains(p.ManualPicking.CheckInId.Value) &&
                            productIds.Contains(p.ReceivedProductId))
                .GroupBy(p => new { CheckInId = p.ManualPicking!.CheckInId!.Value, p.ReceivedProductId })
                .Select(g => new { g.Key.CheckInId, g.Key.ReceivedProductId, Picked = g.Sum(p => (int?)p.QuantityPicked) ?? 0 })
                .ToDictionaryAsync(x => (x.CheckInId, x.ReceivedProductId), x => x.Picked, cancellationToken);

            bool anyUnpicked = false;
            foreach (var checkIn in bin.CheckIns)
            {
                var products = (checkIn.Pallet?.ReceivedProducts != null && checkIn.Pallet.ReceivedProducts.Count > 0)
                    ? checkIn.Pallet.ReceivedProducts
                    : checkIn.ReceivedProducts;

                foreach (var received in products)
                {
                    pickedMap.TryGetValue((checkIn.Id, received.Id), out var pickedQty);
                    if (pickedQty < received.Quantity)
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
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow));
            }

            return Results.Ok(bin.ToSummaryDto());
        })
        .WithName("GetCheckedInBinByQrCode")
        .WithSummary("Locate Checked-In Bin by QR Code")
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
                .FirstOrDefaultAsync(b => b.BinHashCode == binHashCode &&
                    (b.Rack!.WarehouseId == warehouseId || b.WarehouseId == warehouseId), cancellationToken);

            if (bin is null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.UtcNow
                ));
            }

            // Direct check: is there an active check-in tying to this bin?
            bool binIsInUse = await dbContext.CheckIns
                .AsNoTracking()
                .AnyAsync(checkIn => checkIn.IsActive && checkIn.Bins.Any(b => b.Id == bin.Id), cancellationToken);

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
        // Single Item & Structure Lookup
        // -----------------------------------------------------------------------------
        group.MapGet("/{id:int}", async (int id, WMSContext dbContext) =>
        {
            Bin? bin = await dbContext.Bins.FindAsync(id);
            return bin is null ? Results.NotFound() : Results.Ok(bin.ToDetailsDto());
        })
        .WithName(GetBinEndpointName)
        .Produces<BinDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/hashcode/{hashCode:int}/{warehouseId:int}", async (
            int hashCode,
            int warehouseId,
            WMSContext dbContext,
            CancellationToken ct) =>
        {
            var bin = await dbContext.Bins
                .Where(b => b.BinHashCode == hashCode && (b.Rack!.WarehouseId == warehouseId || b.WarehouseId == warehouseId))
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .AsNoTracking()
                .FirstOrDefaultAsync(ct);

            return bin is null
                ? Results.NotFound($"Bin with Hash Code #{hashCode} not found in this warehouse.")
                : Results.Ok(bin.ToSummaryDto());
        })
        .WithName("GetBinByHashCode")
        .Produces<BinSummaryDto>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // Stock Query - FILTERED TO ACTIVE CHECK-INS ONLY
        // -----------------------------------------------------------------------------
        group.MapGet("/stock/id/{BinId:int}", async (
            int BinId,
            WMSContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var binExists = await dbContext.Bins
                .AsNoTracking()
                .AnyAsync(b => b.Id == BinId, cancellationToken);

            if (!binExists)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            // Only inspect ACTIVE check-ins
            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.IsActive && ci.Bins.Any(b => b.Id == BinId))
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

            if (checkIns.Count == 0)
                return Results.Ok(new List<DisplayCheckInProductsDto>());

            var checkInIds = checkIns.Select(ci => ci.Id).ToList();

            var receivedProductIds = checkIns
                .SelectMany(ci => (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Count > 0)
                    ? ci.Pallet.ReceivedProducts
                    : ci.ReceivedProducts)
                .Select(rp => rp.Id)
                .Distinct()
                .ToList();

            // Total picked per product in these specific check-ins
            var pickedMap = await dbContext.PickedProducts
                .AsNoTracking()
                .Where(pp => pp.ManualPicking != null &&
                             pp.ManualPicking.CheckInId.HasValue &&
                             checkInIds.Contains(pp.ManualPicking.CheckInId.Value) &&
                             receivedProductIds.Contains(pp.ReceivedProductId))
                .GroupBy(pp => new { CheckInId = pp.ManualPicking!.CheckInId!.Value, pp.ReceivedProductId })
                .Select(g => new { g.Key.CheckInId, g.Key.ReceivedProductId, PickedQty = g.Sum(pp => pp.QuantityPicked) })
                .ToDictionaryAsync(x => (x.CheckInId, x.ReceivedProductId), x => x.PickedQty, cancellationToken);

            var result = checkIns.Select(ci =>
            {
                var targetProducts = (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Count > 0)
                    ? ci.Pallet.ReceivedProducts
                    : ci.ReceivedProducts;

                var mappedProducts = targetProducts
                    .Select(rp =>
                    {
                        var baseQty = rp.Quantity;
                        pickedMap.TryGetValue((ci.Id, rp.Id), out var pickedQty);
                        var availableQty = baseQty - pickedQty;

                        return new CheckedInProductSumamryDto(
                            id: rp.Id,
                            Name: rp.Product?.Name ?? rp.ExpectedProductName ?? "",
                            TypeOfPackage: rp.TypeOfPackage ?? rp.Product?.TypeOfPackage ?? "",
                            Measurement: rp.Product?.Measurement ?? "",
                            Weight: rp.Product?.Weight ?? 0,
                            Quantity: availableQty,
                            CBM: rp.CBM ?? 0m,
                            TotalWeight: rp.TotalWeight,
                            ExpirationDate: rp.ExpirationDate ?? rp.ExpectedExpirationDate,
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
            .Where(dto => dto.ReceivedProducts.Count > 0)
            .ToList();

            return Results.Ok(result);
        })
        .WithName("GetBinStockById")
        .Produces<List<DisplayCheckInProductsDto>>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

        // -----------------------------------------------------------------------------
        // GET /history/{BinId} (Audit Log: Keeps historical all-time records)
        // -----------------------------------------------------------------------------
        group.MapGet("/history/{BinId:int}", async (int BinId, WMSContext dbContext, CancellationToken ct) =>
        {
            var bin = await dbContext.Bins.FindAsync(new object[] { BinId }, ct);
            if (bin == null)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            var checkIns = await dbContext.CheckIns
                .AsNoTracking()
                .Where(ci => ci.Bins.Any(b => b.Id == BinId))
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Receiving)
                .Include(ci => ci.Pallet)
                .ToListAsync(ct);

            var checkInIds = checkIns.Select(ci => ci.Id).ToList();

            var manualPickings = await dbContext.ManualPickings
                .AsNoTracking()
                .Where(mp => mp.CheckInId != null && checkInIds.Contains(mp.CheckInId.Value))
                .Include(mp => mp.CheckIn)
                .Include(mp => mp.PickedProducts)
                    .ThenInclude(pp => pp.ReceivedProduct)
                        .ThenInclude(rp => rp!.Product)
                .Include(mp => mp.PickedProducts)
                    .ThenInclude(pp => pp.ReceivedProduct)
                        .ThenInclude(rp => rp!.Receiving)
                .OrderBy(mp => mp.PickingDate)
                .ToListAsync(ct);

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

        // -----------------------------------------------------------------------------
        // RACK & BAY FILTERED LOOKUPS
        // -----------------------------------------------------------------------------
        group.MapGet("/rack/{id:int}", async (int id, WMSContext dbContext, CancellationToken ct) =>
            await dbContext.Bins
                .Include(bin => bin.Warehouse)
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Include(bin => bin.Location3D)
                .Where(bin => bin.RackId == id)
                .Select(bin => bin.ToSummaryDto())
                .AsNoTracking()
                .ToListAsync(ct)
        ).Produces<List<BinSummaryDto>>(StatusCodes.Status200OK);

        group.MapGet("/rack/{rackId:int}/bay/{bayId:int}", async (
            int rackId,
            int bayId,
            WMSContext dbContext,
            CancellationToken ct) =>
            await dbContext.Bins
                .Include(bin => bin.Warehouse)
                .Include(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
                .Include(bin => bin.Bay)
                .Include(bin => bin.Level)
                .Include(bin => bin.BinNames)
                .Include(bin => bin.Location3D)
                .Where(bin => bin.RackId == rackId && bin.BayId == bayId)
                .Select(bin => bin.ToSummaryDto())
                .AsNoTracking()
                .ToListAsync(ct)
        );

        // -----------------------------------------------------------------------------
        // MUTATIONS (CREATE / UPDATE / DELETE)
        // -----------------------------------------------------------------------------
        group.MapPost("/", async (
            CreateBinDto newBin,
            WMSContext dbContext,
            IAuditLogService auditLogService) =>
        {
            Bin bin = newBin.ToEntity();
            dbContext.Bins.Add(bin);
            await dbContext.SaveChangesAsync();

            var createdBin = await dbContext.Bins
                .Include(b => b.Warehouse)
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .Include(b => b.Location3D)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == bin.Id);

            var details = (createdBin ?? bin).ToSummaryDto();

            await auditLogService.LogAsync(
                category: "Warehouse Structure",
                action: "Created",
                description: $"Created new Bin location '{details.BinName}' (Hash Code: {details.BinHashCode}, ID: {bin.Id}).",
                details: new
                {
                    BinId = bin.Id,
                    BinName = details.BinName,
                    BinHashCode = details.BinHashCode,
                    RackId = bin.RackId,
                    BayId = bin.BayId,
                    LevelId = bin.LevelId,
                    BinNamesId = bin.BinNamesId,
                    IsStandalone = bin.RackId == null
                }
            );

            return Results.CreatedAtRoute(GetBinEndpointName, new { id = bin.Id }, details);
        })
        .WithName("CreateBin")
        .Accepts<CreateBinDto>("application/json")
        .Produces<BinSummaryDto>(StatusCodes.Status201Created);

        group.MapPatch("/{id:int}/location", async (
            int id,
            UpdateBinLocation3DDto locationDto,
            WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins
                .Include(b => b.Location3D)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bin is null) return Results.NotFound();

            bin.Location3D ??= new Location3D();
            bin.Location3D.PositionX = locationDto.PositionX;
            bin.Location3D.PositionY = locationDto.PositionY;
            bin.Location3D.PositionZ = locationDto.PositionZ;
            bin.Location3D.RotationY = locationDto.RotationY;

            await dbContext.SaveChangesAsync();
            return Results.Ok(bin.ToSummaryDto());
        })
        .WithName("UpdateBin3DLocation")
        .Produces<BinSummaryDto>(StatusCodes.Status200OK);

        group.MapPut("/{id:int}", async (
            int id,
            UpdateBinDto updatedBin,
            WMSContext dbContext,
            IAuditLogService auditLogService) =>
        {
            var existingBin = await dbContext.Bins
                .Include(b => b.Rack)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (existingBin is null)
                return Results.NotFound();

            var oldDetails = existingBin.ToSummaryDto();
            dbContext.Entry(existingBin).CurrentValues.SetValues(updatedBin.ToEntity(id));
            await dbContext.SaveChangesAsync();

            var updatedBinHydrated = await dbContext.Bins
                .Include(b => b.Rack)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            var newDetails = (updatedBinHydrated ?? existingBin).ToSummaryDto();

            await auditLogService.LogAsync(
                category: "Warehouse Structure",
                action: "Updated",
                description: $"Updated Bin location ID {id} ('{oldDetails.BinName}' -> '{newDetails.BinName}').",
                details: new
                {
                    BinId = id,
                    OldBinName = oldDetails.BinName,
                    NewBinName = newDetails.BinName,
                    OldBinHashCode = oldDetails.BinHashCode,
                    NewBinHashCode = newDetails.BinHashCode
                }
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (
            int id,
            WMSContext dbContext,
            IAuditLogService auditLogService,
            CancellationToken ct) =>
        {
            var existingBin = await dbContext.Bins
                .Include(b => b.BinNames)
                .FirstOrDefaultAsync(b => b.Id == id, ct);

            if (existingBin is null)
                return Results.NotFound();

            // Safety check: verify the bin does not have ACTIVE check-ins
            bool hasActiveCheckIns = await dbContext.CheckIns
                .AnyAsync(ci => ci.IsActive && ci.Bins.Any(b => b.Id == id), ct);

            if (hasActiveCheckIns)
            {
                return Results.BadRequest(new
                {
                    Message = $"Cannot delete bin '{existingBin.BinNames?.BinName ?? id.ToString()}' because it currently contains active inventory."
                });
            }

            var snapshotDetails = existingBin.ToSummaryDto();
            dbContext.Bins.Remove(existingBin);
            await dbContext.SaveChangesAsync(ct);

            await auditLogService.LogAsync(
                category: "Warehouse Structure",
                action: "Deleted",
                description: $"Deleted Bin location '{snapshotDetails.BinName}' (ID: {id}).",
                details: new { DeletedBinId = id, BinName = snapshotDetails.BinName }
            );

            return Results.NoContent();
        });

        return group;
    }
}