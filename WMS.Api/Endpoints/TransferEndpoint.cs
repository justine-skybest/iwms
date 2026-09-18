using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Transfer;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints;

public static class TransferEndpoint
{
    public static RouteGroupBuilder MapTransferEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transfers").WithParameterValidation();

        // -----------------------------------------------------------------------------
        // Pallet Location Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/pallet/locate/number/{palletNumber:int}/{warehouseId:int}", async (int palletNumber, int warehouseId, WMSContext dbContext) =>
            await LocatePallet(dbContext, pallet => pallet.PalletNumber == palletNumber && pallet.WarehouseId == warehouseId)
        )
        .WithName("LocatePalletByNumber")
        .WithSummary("Locate a pallet by its pallet number")
        .WithDescription("Finds a pallet by pallet number within a warehouse and returns its current bin location, if checked in.")
        .Produces<PalletLocationDto>(StatusCodes.Status200OK);

        group.MapGet("/pallet/locate/qrcode/{hashCode:int}/{warehouseId:int}", async (int hashCode, int warehouseId, WMSContext dbContext) =>
            await LocatePallet(dbContext, pallet => pallet.PalletHashCode == hashCode && pallet.WarehouseId == warehouseId)
        )
        .WithName("LocatePalletByQrCode")
        .WithSummary("Locate a pallet by its QR code hash")
        .WithDescription("Finds a pallet by its QR code hash within a warehouse and returns its current bin location, if checked in.")
        .Produces<PalletLocationDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Pallet & Item Transfer Operations
        // -----------------------------------------------------------------------------
        group.MapPost("/pallet", async (TransferPalletDto request, WMSContext dbContext) =>
        {
            var checkIn = await dbContext.CheckIns
                .Include(checkIn => checkIn.Bins)
                .FirstOrDefaultAsync(checkIn => checkIn.PalletId == request.PalletId);

            if (checkIn is null)
            {
                return Results.Ok(new TransferResultDto(false, "This pallet is not currently checked in to any bin location."));
            }

            var toBin = await dbContext.Bins.Include(bin => bin.Rack).FirstOrDefaultAsync(bin => bin.Id == request.ToBinId);
            if (toBin is null)
            {
                return Results.Ok(new TransferResultDto(false, "Destination bin not found."));
            }

            if (checkIn.Bins.Any(bin => bin.Id == request.ToBinId))
            {
                return Results.Ok(new TransferResultDto(false, "The pallet is already in that bin location."));
            }

            if (await IsBinOccupied(dbContext, request.ToBinId, excludeCheckInId: checkIn.Id))
            {
                return Results.Ok(new TransferResultDto(false, "The destination bin location is already occupied."));
            }

            var fromBinId = checkIn.Bins.First().Id;

            checkIn.Bins.Clear();
            checkIn.Bins.Add(toBin);
            checkIn.Notes = AppendTransferNote(checkIn.Notes, request.Notes);

            dbContext.TransferLogs.Add(new TransferLog
            {
                TransferType = "Pallet",
                WarehouseId = toBin.Rack!.WarehouseId,
                PalletId = request.PalletId,
                FromBinId = fromBinId,
                ToBinId = toBin.Id,
                TransferDate = DateTime.Now,
                Notes = request.Notes
            });

            await dbContext.SaveChangesAsync();

            return Results.Ok(new TransferResultDto(true, "Pallet successfully transferred."));
        })
        .WithName("TransferPallet")
        .WithSummary("Transfer a whole pallet to a new bin")
        .WithDescription("Moves a checked-in pallet (and all its contents) from its current bin to a destination bin, logging the transfer.")
        .Accepts<TransferPalletDto>("application/json")
        .Produces<TransferResultDto>(StatusCodes.Status200OK);

        group.MapPost("/item", async (TransferItemDto request, WMSContext dbContext) =>
        {
            var checkIn = await dbContext.CheckIns
                .Include(checkIn => checkIn.Bins)
                .Include(checkIn => checkIn.ReceivedProducts)
                .FirstOrDefaultAsync(checkIn => checkIn.Id == request.FromCheckInId);

            if (checkIn is null)
            {
                return Results.Ok(new TransferResultDto(false, "Source check-in record not found."));
            }

            var receivedProduct = checkIn.ReceivedProducts.FirstOrDefault(receivedProduct => receivedProduct.Id == request.ReceivedProductId);
            if (receivedProduct is null)
            {
                return Results.Ok(new TransferResultDto(false, "This item is not part of the source location."));
            }

            var toBin = await dbContext.Bins.Include(bin => bin.Rack).FirstOrDefaultAsync(bin => bin.Id == request.ToBinId);
            if (toBin is null)
            {
                return Results.Ok(new TransferResultDto(false, "Destination bin not found."));
            }

            if (checkIn.Bins.Any(bin => bin.Id == request.ToBinId))
            {
                return Results.Ok(new TransferResultDto(false, "This item is already in that bin location."));
            }

            if (await IsBinOccupied(dbContext, request.ToBinId))
            {
                return Results.Ok(new TransferResultDto(false, "The destination bin location is already occupied."));
            }

            var fromBinId = checkIn.Bins.First().Id;

            checkIn.ReceivedProducts.Remove(receivedProduct);

            var newCheckIn = new CheckIn
            {
                CheckInType = "ByItem",
                Bins = new List<Bin> { toBin },
                ReceivedProducts = new List<ReceivedProduct> { receivedProduct },
                CheckInDate = DateTime.Now,
                Notes = AppendTransferNote(null, request.Notes)
            };
            dbContext.CheckIns.Add(newCheckIn);

            dbContext.TransferLogs.Add(new TransferLog
            {
                TransferType = "Item",
                WarehouseId = toBin.Rack!.WarehouseId,
                ReceivedProductId = receivedProduct.Id,
                FromBinId = fromBinId,
                ToBinId = toBin.Id,
                TransferDate = DateTime.Now,
                Notes = request.Notes
            });

            await dbContext.SaveChangesAsync();

            return Results.Ok(new TransferResultDto(true, "Item successfully transferred."));
        })
        .WithName("TransferItem")
        .WithSummary("Transfer a single item to a new bin")
        .WithDescription("Moves a single received product out of its current check-in and into a new check-in at the destination bin, logging the transfer.")
        .Accepts<TransferItemDto>("application/json")
        .Produces<TransferResultDto>(StatusCodes.Status200OK);

        // -----------------------------------------------------------------------------
        // Query & Report Endpoints
        // -----------------------------------------------------------------------------
        group.MapGet("/report", async (DateTime from, DateTime to, int? warehouseId, WMSContext dbContext) =>
        {
            var query = dbContext.TransferLogs
                .Where(log => log.TransferDate.Date >= from.Date && log.TransferDate.Date <= to.Date);

            if (warehouseId.HasValue && warehouseId.Value > 0)
            {
                query = query.Where(log => log.WarehouseId == warehouseId);
            }

            var logs = await query.OrderByDescending(log => log.TransferDate).ToListAsync();

            var palletIds = logs.Where(log => log.PalletId.HasValue).Select(log => log.PalletId!.Value).Distinct().ToList();
            var receivedProductIds = logs.Where(log => log.ReceivedProductId.HasValue).Select(log => log.ReceivedProductId!.Value).Distinct().ToList();
            var binIds = logs.SelectMany(log => new[] { log.FromBinId, log.ToBinId }).Distinct().ToList();

            var pallets = await dbContext.Pallets
                .Where(pallet => palletIds.Contains(pallet.Id))
                .Select(pallet => new { pallet.Id, pallet.PalletNumber })
                .ToDictionaryAsync(pallet => pallet.Id, pallet => pallet.PalletNumber);

            var products = await dbContext.ReceivedProducts
                .Where(receivedProduct => receivedProductIds.Contains(receivedProduct.Id))
                .Select(receivedProduct => new { receivedProduct.Id, Name = receivedProduct.Product!.Name })
                .ToDictionaryAsync(receivedProduct => receivedProduct.Id, receivedProduct => receivedProduct.Name);

            var bins = await dbContext.Bins
                .Where(bin => binIds.Contains(bin.Id))
                .Select(bin => new
                {
                    bin.Id,
                    Location = bin.Rack!.Name + " / Bay " + bin.Bay!.BayNumber + " / Level " + bin.Level!.LevelNumber + " / " + bin.BinNames!.BinName
                })
                .ToDictionaryAsync(bin => bin.Id, bin => bin.Location);

            var result = logs.Select(log => new TransferLogDto(
                log.Id,
                log.TransferType,
                log.PalletId.HasValue && pallets.TryGetValue(log.PalletId.Value, out var palletNumber)
                    ? $"Pallet #{palletNumber}"
                    : log.ReceivedProductId.HasValue && products.TryGetValue(log.ReceivedProductId.Value, out var productName)
                        ? productName
                        : "Unknown",
                bins.TryGetValue(log.FromBinId, out var fromLocation) ? fromLocation : "Unknown",
                bins.TryGetValue(log.ToBinId, out var toLocation) ? toLocation : "Unknown",
                log.TransferDate,
                log.Notes
            )).ToList();

            return Results.Ok(result);
        })
        .WithName("GetTransferReport")
        .WithSummary("Get a transfer log report")
        .WithDescription("Returns transfer log entries within a date range, optionally scoped to a single warehouse.")
        .Produces<List<TransferLogDto>>(StatusCodes.Status200OK);

        group.MapGet("/item/bin/{binId:int}", async (int binId, WMSContext dbContext) =>
        {
            var checkIns = await dbContext.CheckIns
                .Where(checkIn => checkIn.Bins.Any(bin => bin.Id == binId) && checkIn.PalletId == null)
                .Include(checkIn => checkIn.ReceivedProducts)
                    .ThenInclude(receivedProduct => receivedProduct.Product)
                .Include(checkIn => checkIn.ReceivedProducts)
                    .ThenInclude(receivedProduct => receivedProduct.Receiving)
                .ToListAsync();

            var items = checkIns
                .SelectMany(checkIn => checkIn.ReceivedProducts.Select(receivedProduct => new ItemLocationSummaryDto(
                    receivedProduct.Id,
                    checkIn.Id,
                    receivedProduct.Product!.Name,
                    receivedProduct.Product!.TypeOfPackage,
                    receivedProduct.Quantity,
                    receivedProduct.Receiving!.Series
                )))
                .ToList();

            return Results.Ok(items);
        })
        .WithName("GetItemsInBin")
        .WithSummary("List individually checked-in items in a bin")
        .WithDescription("Returns item-level (non-pallet) received products currently checked in to the given bin.")
        .Produces<List<ItemLocationSummaryDto>>(StatusCodes.Status200OK);

        return group;
    }

    private static async Task<IResult> LocatePallet(WMSContext dbContext, Expression<Func<Pallet, bool>> predicate)
    {
        var pallet = await dbContext.Pallets.FirstOrDefaultAsync(predicate);
        if (pallet is null)
        {
            return Results.Ok(new PalletLocationDto(0, 0, 0, 0, null, null, null, "Pallet not found."));
        }

        var checkIn = await dbContext.CheckIns
            .Include(checkIn => checkIn.Bins)
                .ThenInclude(bin => bin.Rack)
                    .ThenInclude(rack => rack!.Warehouse)
            .Include(checkIn => checkIn.Bins)
                .ThenInclude(bin => bin.Bay)
            .Include(checkIn => checkIn.Bins)
                .ThenInclude(bin => bin.Level)
            .Include(checkIn => checkIn.Bins)
                .ThenInclude(bin => bin.BinNames)
            .FirstOrDefaultAsync(checkIn => checkIn.PalletId == pallet.Id);

        if (checkIn is null || !checkIn.Bins.Any())
        {
            return Results.Ok(new PalletLocationDto(
                pallet.Id, pallet.WarehouseId, pallet.PalletNumber, pallet.PalletHashCode,
                null, null, null,
                "This pallet is not currently checked in to any bin location."
            ));
        }

        var bin = checkIn.Bins.First();

        return Results.Ok(new PalletLocationDto(
            pallet.Id, pallet.WarehouseId, pallet.PalletNumber, pallet.PalletHashCode,
            checkIn.Id, bin.Id,
            $"{bin.Rack!.Warehouse!.Name} / {bin.Rack.Name} / Bay {bin.Bay!.BayNumber} / Level {bin.Level!.LevelNumber} / {bin.BinNames!.BinName}",
            null
        ));
    }

    private static async Task<bool> IsBinOccupied(WMSContext dbContext, int binId, int? excludeCheckInId = null)
    {
        var checkIns = await dbContext.CheckIns
            .Where(checkIn => checkIn.Bins.Any(bin => bin.Id == binId))
            .Where(checkIn => excludeCheckInId == null || checkIn.Id != excludeCheckInId)
            .Include(checkIn => checkIn.ReceivedProducts)
            .ToListAsync();

        foreach (var checkIn in checkIns)
        {
            foreach (var receivedProduct in checkIn.ReceivedProducts)
            {
                var picked = await dbContext.PickedProducts
                    .Where(pickedProduct => pickedProduct.ReceivedProductId == receivedProduct.Id &&
                        pickedProduct.ManualPicking != null &&
                        pickedProduct.ManualPicking.CheckInId == checkIn.Id)
                    .SumAsync(pickedProduct => (int?)pickedProduct.QuantityPicked) ?? 0;

                if (picked < receivedProduct.Quantity)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static string? AppendTransferNote(string? existingNotes, string? transferNotes)
    {
        var note = string.IsNullOrWhiteSpace(transferNotes) ? "Transferred" : $"Transferred: {transferNotes}";
        return string.IsNullOrWhiteSpace(existingNotes) ? note : $"{existingNotes} | {note}";
    }
}