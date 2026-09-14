using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
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

        group.MapGet("CheckedIn/{BinHashCode:int}/{WarehouseId:int}", async (int BinHashCode, int WarehouseId, WMSContext dbContext) =>
        {
            // Load bin with related entities
            var bin = await dbContext.Bins
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .FirstOrDefaultAsync(b => b.BinHashCode == BinHashCode && b.Rack!.WarehouseId == WarehouseId);

            if (bin == null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.Now));
            }

            // Get all CheckIns linked to this bin with ReceivedProducts loaded
            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == bin.Id))
                .Include(ci => ci.ReceivedProducts)
                .ToListAsync();

            if (!checkIns.Any())
            {
                // Bin has no CheckIns, so considered empty
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently empty.",
                    "Empty", "Empty", "Empty", "Empty", "Empty", DateTime.Now));
            }

            // Check if any CheckIn has unpicked quantity
            bool anyUnpicked = false;
            foreach (var checkIn in checkIns)
            {
                foreach (var received in checkIn.ReceivedProducts)
                {
                    var totalPicked = await dbContext.PickedProducts
                        .Where(p =>
                            p.ReceivedProductId == received.Id &&
                            p.ManualPicking != null &&
                            p.ManualPicking.CheckInId == checkIn.Id)
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

            // Otherwise return the bin summary DTO
            return Results.Ok(bin.ToSummaryDto());
        });

        group.MapGet("/QRCode/{BinHashCode:int}/{WarehouseId:int}", async (int BinHashCode, int WarehouseId, WMSContext dbContext) =>
        {
            // Get the bin with related entities
            var bin = await dbContext.Bins
                .Include(b => b.Rack)
                    .ThenInclude(r => r!.Warehouse)
                .Include(b => b.Bay)
                .Include(b => b.Level)
                .Include(b => b.BinNames)
                .Where(b => b.BinHashCode == BinHashCode && b.Rack!.WarehouseId == WarehouseId)
                .FirstOrDefaultAsync();

            if (bin is null)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is not present on any bin location in this warehouse.",
                    "Empty",   
                    "Empty",   
                    "Empty",  
                    "Empty",     
                    "Empty",     
                    DateTime.Now 
                ));
            }

            bool binIsInUse = await dbContext.CheckIns
            .Where(checkIn => checkIn.Bins.Any(b => b.Id == bin.Id))
            .AnyAsync(checkIn =>
                checkIn.ReceivedProducts.Any(received =>
                    dbContext.PickedProducts
                        .Where(p =>
                            p.ReceivedProductId == received.Id &&
                            p.ManualPicking != null &&
                            p.ManualPicking.CheckInId == checkIn.Id &&
                            checkIn.Bins.Any(b => b.Id == p.ManualPicking.BinId)
                        )
                        .Sum(p => p.QuantityPicked) < received.Quantity
                )
            );

            if (binIsInUse)
            {
                return Results.Ok(new BinSummaryDto(
                    0,
                    "This QR code is from a bin location that is currently in use.",
                    "Empty",   
                    "Empty",   
                    "Empty",  
                    "Empty",     
                    "Empty",     
                    DateTime.Now 
                ));
            }

            return Results.Ok(bin.ToSummaryDto());
        });

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
        );

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

        group.MapGet("/{id}", async (int id, WMSContext dbContext) =>
        {
            Bin? bin = await dbContext.Bins.FindAsync(id);

            return bin is null ? Results.NotFound() : Results.Ok(bin.ToDetailsDto());
        }).WithName(GetBinEndpointName);
        
        group.MapGet("/stock/id/{BinId}", async (int BinId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins.FindAsync(BinId);
            if (bin == null)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            // Get all check-ins involving this bin
            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == BinId))
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Receiving)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.Pallet)
                .ToListAsync();

            if (!checkIns.Any())
                return Results.Ok(new List<DisplayCheckInProductsDto>());

            // Get all picked quantities for these CheckIns (regardless of picking bin)
            var checkInIds = checkIns.Select(ci => ci.Id).ToList();

            var pickedMap = await dbContext.PickedProducts
                .Where(pp =>
                    pp.ManualPicking != null &&
                    pp.ManualPicking.CheckInId != null &&
                    checkInIds.Contains(pp.ManualPicking.CheckInId.Value))
                .GroupBy(pp => pp.ReceivedProductId)
                .ToDictionaryAsync(g => g.Key, g => g.Sum(pp => pp.QuantityPicked));

            // Assemble DTOs
            var result = checkIns.Select(ci => new DisplayCheckInProductsDto(
                Id: ci.Id,
                CheckInType: ci.CheckInType,
                PalletNumber: ci.Pallet?.PalletNumber != null ? "Pallet #" + ci.Pallet.PalletNumber : "",
                ReceivedProducts: ci.ReceivedProducts
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
                            PalletId: rp.PalletId?.ToString(),
                            ReceivingSeries: rp!.Receiving!.Series,
                            Shipper: rp!.Receiving!.Shipper
                            
                        );
                    })
                    .Where(rp => rp.Quantity > 0)
                    .ToList(),
                CheckInDate: ci.CheckInDate,
                Notes: ci.Notes
            ))
            .Where(dto => dto.ReceivedProducts.Any())
            .ToList();

            return Results.Ok(result);
        });

        group.MapGet("/history/{BinId}", async (int BinId, WMSContext dbContext) =>
        {
            var bin = await dbContext.Bins.FindAsync(BinId);
            if (bin == null)
                return Results.NotFound($"Bin with ID#{BinId} not found.");

            // 1. Get all CheckIns where this bin is assigned
            var checkIns = await dbContext.CheckIns
                .Where(ci => ci.Bins.Any(b => b.Id == BinId))
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Product)
                .Include(ci => ci.ReceivedProducts)
                    .ThenInclude(rp => rp.Receiving)
                .Include(ci => ci.Pallet)
                .ToListAsync();

            var checkInIds = checkIns.Select(ci => ci.Id).ToList();

            // 2. Get ManualPickings tied to those CheckIns (regardless of bin)
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

            // 3. Build movement history with cumulative picked tracking
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
