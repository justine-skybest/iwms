using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;
using WMS.Api.Dtos.Transfer;
using WMS.Api.Entities;

namespace WMS.Api.Endpoints;

public static class TransferV2Endpoint
{
    public static RouteGroupBuilder MapTransferV2Endpoints(this WebApplication app)
    {
        var group = app.MapGroup("transfers-v2")
            .WithTags("Transfers V2")
            .WithParameterValidation();

        // -----------------------------------------------------------------------------
        // Bin-to-Bin Bulk Transfer Endpoint (Primary Warehouse Operation)
        // -----------------------------------------------------------------------------
        group.MapPost("/bin", async (TransferBinDto request, WMSContext dbContext) =>
        {
            if (request.FromBinId == request.ToBinId)
            {
                return Results.Ok(new TransferResultDto(false, "Destination bin must be different from source bin."));
            }

            var toBin = await dbContext.Bins
                .Include(bin => bin.Rack)
                .FirstOrDefaultAsync(bin => bin.Id == request.ToBinId);

            if (toBin is null)
            {
                return Results.Ok(new TransferResultDto(false, "Destination bin location not found."));
            }

            // Retrieve all active check-ins currently located at the source bin
            var checkIns = await dbContext.CheckIns
                .Include(checkIn => checkIn.Bins)
                .Include(checkIn => checkIn.ReceivedProducts)
                .Where(checkIn => checkIn.Bins.Any(bin => bin.Id == request.FromBinId))
                .ToListAsync();

            if (!checkIns.Any())
            {
                return Results.Ok(new TransferResultDto(false, "Source bin has no active checked-in inventory to transfer."));
            }

            // Check if destination bin is occupied by other check-ins
            if (await IsBinOccupied(dbContext, request.ToBinId))
            {
                return Results.Ok(new TransferResultDto(false, "The destination bin location is already occupied."));
            }

            int palletsMoved = 0;
            int itemsMoved = 0;

            foreach (var checkIn in checkIns)
            {
                // 1. Unlink Pallet & Received Products from the source check-in record
                var palletId = checkIn.PalletId;
                checkIn.PalletId = null;

                var productsToMove = checkIn.ReceivedProducts.ToList();
                foreach (var product in productsToMove)
                {
                    checkIn.ReceivedProducts.Remove(product);
                }

                var fromBin = checkIn.Bins.FirstOrDefault(bin => bin.Id == request.FromBinId);
                if (fromBin is not null)
                {
                    checkIn.Bins.Remove(fromBin);
                }

                // 2. Create a new CheckIn entry at the destination Bin
                var newCheckIn = new CheckIn
                {
                    CheckInType = string.IsNullOrWhiteSpace(checkIn.CheckInType)
                        ? (palletId.HasValue ? "ByPallet" : "ByItem")
                        : checkIn.CheckInType,
                    PalletId = palletId,
                    Bins = new List<Bin> { toBin },
                    ReceivedProducts = productsToMove,
                    CheckInDate = DateTime.Now,
                    Notes = AppendTransferNote(null, request.Notes)
                };

                dbContext.CheckIns.Add(newCheckIn);

                // 3. Log Transfer Audit Entries
                if (palletId.HasValue)
                {
                    palletsMoved++;
                    dbContext.TransferLogs.Add(new TransferLog
                    {
                        TransferType = "Pallet",
                        WarehouseId = toBin.Rack!.WarehouseId,
                        PalletId = palletId,
                        FromBinId = request.FromBinId,
                        ToBinId = request.ToBinId,
                        TransferDate = DateTime.Now,
                        Notes = request.Notes
                    });
                }
                else
                {
                    foreach (var item in productsToMove)
                    {
                        itemsMoved++;
                        dbContext.TransferLogs.Add(new TransferLog
                        {
                            TransferType = "Item",
                            WarehouseId = toBin.Rack!.WarehouseId,
                            ReceivedProductId = item.Id,
                            FromBinId = request.FromBinId,
                            ToBinId = request.ToBinId,
                            TransferDate = DateTime.Now,
                            Notes = request.Notes
                        });
                    }
                }
            }

            await dbContext.SaveChangesAsync();

            var summary = (palletsMoved > 0, itemsMoved > 0) switch
            {
                (true, true) => $"{palletsMoved} pallet(s) and {itemsMoved} loose item(s) successfully transferred.",
                (true, false) => $"{palletsMoved} pallet(s) successfully transferred.",
                _ => $"{itemsMoved} item(s) successfully transferred."
            };

            return Results.Ok(new TransferResultDto(true, summary));
        })
        .WithName("TransferBinContents")
        .WithSummary("Transfer all contents from one bin to another")
        .WithDescription("Transfers all checked-in pallets and individual items from a source bin into new check-in records at the destination bin.")
        .Accepts<TransferBinDto>("application/json")
        .Produces<TransferResultDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        // -----------------------------------------------------------------------------
        // Specific Pallet & Item Transfer Overrides
        // -----------------------------------------------------------------------------
        group.MapPost("/pallet", async (TransferPalletDto request, WMSContext dbContext) =>
        {
            var checkIn = await dbContext.CheckIns
                .Include(checkIn => checkIn.Bins)
                .Include(checkIn => checkIn.ReceivedProducts)
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

            // Unlink Pallet and Received Products from source CheckIn
            var palletId = checkIn.PalletId;
            checkIn.PalletId = null;

            var productsToMove = checkIn.ReceivedProducts.ToList();
            foreach (var product in productsToMove)
            {
                checkIn.ReceivedProducts.Remove(product);
            }

            var fromBin = checkIn.Bins.FirstOrDefault(bin => bin.Id == fromBinId);
            if (fromBin is not null)
            {
                checkIn.Bins.Remove(fromBin);
            }

            // Create a new CheckIn entry at the destination Bin
            var newCheckIn = new CheckIn
            {
                CheckInType = string.IsNullOrWhiteSpace(checkIn.CheckInType) ? "ByPallet" : checkIn.CheckInType,
                PalletId = palletId,
                Bins = new List<Bin> { toBin },
                ReceivedProducts = productsToMove,
                CheckInDate = DateTime.Now,
                Notes = AppendTransferNote(null, request.Notes)
            };

            dbContext.CheckIns.Add(newCheckIn);

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
        .WithName("TransferPalletV2")
        .WithSummary("Transfer a whole pallet to a new bin")
        .WithDescription("Moves a checked-in pallet (and all its contents) from its current bin into a new check-in record at the destination bin.")
        .Accepts<TransferPalletDto>("application/json")
        .Produces<TransferResultDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

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
        .WithName("TransferItemV2")
        .WithSummary("Transfer a single item to a new bin")
        .WithDescription("Moves a single received product out of its current check-in into a new check-in at the destination bin.")
        .Accepts<TransferItemDto>("application/json")
        .Produces<TransferResultDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

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
        .WithName("GetTransferReportV2")
        .WithSummary("Get a transfer log report")
        .WithDescription("Returns transfer log entries within a date range, optionally scoped to a single warehouse.")
        .Produces<List<TransferLogDto>>(StatusCodes.Status200OK)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest);

        return group;
    }

    private static async Task<bool> IsBinOccupied(WMSContext dbContext, int binId, int? excludeCheckInId = null)
    {
        var checkIns = await dbContext.CheckIns
            .Where(checkIn => checkIn.Bins.Any(bin => bin.Id == binId))
            .Where(checkIn => excludeCheckInId == null || checkIn.Id != excludeCheckInId)
            .Include(checkIn => checkIn.ReceivedProducts)
            .Include(checkIn => checkIn.Pallet)
                .ThenInclude(pallet => pallet!.ReceivedProducts)
            .AsNoTracking()
            .ToListAsync();

        if (!checkIns.Any()) return false;

        var receivedProductIds = checkIns
            .SelectMany(ci => (ci.Pallet?.ReceivedProducts != null && ci.Pallet.ReceivedProducts.Any())
                ? ci.Pallet.ReceivedProducts
                : ci.ReceivedProducts)
            .Select(rp => rp.Id)
            .Distinct()
            .ToList();

        if (!receivedProductIds.Any()) return false;

        // Query total picked quantities globally by ReceivedProductId across all past check-ins
        var pickedMap = await dbContext.PickedProducts
            .Where(pp => receivedProductIds.Contains(pp.ReceivedProductId))
            .GroupBy(pp => pp.ReceivedProductId)
            .ToDictionaryAsync(g => g.Key, g => g.Sum(pp => pp.QuantityPicked));

        foreach (var checkIn in checkIns)
        {
            var products = (checkIn.Pallet?.ReceivedProducts != null && checkIn.Pallet.ReceivedProducts.Any())
                ? checkIn.Pallet.ReceivedProducts
                : checkIn.ReceivedProducts;

            foreach (var receivedProduct in products)
            {
                var totalPicked = pickedMap.TryGetValue(receivedProduct.Id, out var qty) ? qty : 0;
                if (totalPicked < receivedProduct.Quantity)
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