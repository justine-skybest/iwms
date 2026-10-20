using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;

namespace WMS.Api.Endpoints.ReportsEndpoints
{
    public static class OccupancyReportEndpoints
    {
        public static RouteGroupBuilder MapOccupancyReportEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/warehouse-occupancy", async (
                WMSContext dbContext,
                int? warehouseId,
                int? rackId,
                CancellationToken cancellationToken) =>
            {
                var query = dbContext.Bins.AsNoTracking();

                // 1. Support both racked bins and standalone warehouse bins
                if (warehouseId.HasValue)
                {
                    query = query.Where(bin =>
                        bin.WarehouseId == warehouseId.Value ||
                        (bin.Rack != null && bin.Rack.WarehouseId == warehouseId.Value));
                }

                if (rackId.HasValue)
                {
                    query = query.Where(bin => bin.RackId == rackId.Value);
                }

                // 2. Project ONLY ACTIVE check-ins
                var rawBinData = await query
                    .Select(bin => new
                    {
                        bin.Id,
                        BinName = bin.BinNames != null ? bin.BinNames.BinName : null,
                        bin.RackId,
                        RackName = bin.Rack != null ? bin.Rack.Name : "Standalone",
                        BayNumber = bin.Bay != null ? (int?)bin.Bay.BayNumber : null,
                        LevelNumber = bin.Level != null ? (int?)bin.Level.LevelNumber : null,
                        // Filter directly at the database query level
                        CheckIns = bin.CheckIns
                            .Where(ci => ci.IsActive)
                            .Select(ci => new
                            {
                                ci.Id,
                                ci.CheckInType,
                                ci.CheckInDate,
                                ci.PalletId,
                                ci.Notes,
                                DirectProducts = ci.ReceivedProducts.Select(rp => new
                                {
                                    rp.ReceivingId,
                                    ProductName = rp.Product != null ? rp.Product.Name : rp.ExpectedProductName,
                                    OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity.Value : rp.Quantity,
                                    // Scope picked quantity to this specific check-in
                                    PickedQuantity = dbContext.PickedProducts
                                        .Where(pp => pp.ReceivedProductId == rp.Id &&
                                                     pp.ManualPicking != null &&
                                                     pp.ManualPicking.CheckInId == ci.Id)
                                        .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                    rp.LotNumber,
                                    rp.ContainerName,
                                    rp.ExpectedExpirationDate
                                }).ToList(),
                                PalletProducts = ci.Pallet != null
                                    ? ci.Pallet.ReceivedProducts.Select(rp => new
                                    {
                                        rp.ReceivingId,
                                        ProductName = rp.Product != null ? rp.Product.Name : rp.ExpectedProductName,
                                        OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity.Value : rp.Quantity,
                                        // Scope picked quantity to this specific check-in
                                        PickedQuantity = dbContext.PickedProducts
                                            .Where(pp => pp.ReceivedProductId == rp.Id &&
                                                         pp.ManualPicking != null &&
                                                         pp.ManualPicking.CheckInId == ci.Id)
                                            .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                        rp.LotNumber,
                                        rp.ContainerName,
                                        rp.ExpectedExpirationDate
                                    }).ToList()
                                    : null
                            }).ToList()
                    })
                    .ToListAsync(cancellationToken);

                var binData = rawBinData.Select(bin =>
                {
                    var activeCheckIns = bin.CheckIns.Select(ci =>
                    {
                        var targetProducts = (ci.PalletProducts != null && ci.PalletProducts.Count > 0)
                            ? ci.PalletProducts
                            : ci.DirectProducts;

                        var remainingProducts = targetProducts
                            .Select(p => new
                            {
                                Product = p,
                                RemainingQuantity = p.OriginalQuantity - p.PickedQuantity
                            })
                            .Where(x => x.RemainingQuantity > 0)
                            .Select(x => new CheckInProductDto(
                                x.Product.ReceivingId,
                                x.Product.ProductName ?? "Unknown Product",
                                x.RemainingQuantity,
                                x.Product.LotNumber,
                                x.Product.ContainerName,
                                x.Product.ExpectedExpirationDate
                            ))
                            .ToList();

                        return new
                        {
                            ci.Id,
                            ci.CheckInType,
                            ci.CheckInDate,
                            ci.PalletId,
                            ci.Notes,
                            Products = remainingProducts
                        };
                    })
                    .Where(ci => ci.Products.Count > 0)
                    .Select(ci => new BinCheckInDto(
                        ci.Id,
                        ci.CheckInType,
                        ci.CheckInDate,
                        ci.PalletId,
                        ci.Notes,
                        ci.Products
                    ))
                    .ToList();

                    bool isOccupied = activeCheckIns.Count > 0;

                    return new BinOccupancyDto(
                        bin.Id,
                        bin.BinName,
                        bin.RackId,
                        bin.RackName,
                        bin.BayNumber,
                        bin.LevelNumber,
                        isOccupied,
                        activeCheckIns
                    );
                }).ToList();

                var totalBins = binData.Count;
                var occupiedBins = binData.Count(b => b.IsOccupied);
                var vacantBins = totalBins - occupiedBins;
                var occupancyRate = totalBins > 0 ? (double)occupiedBins / totalBins * 100 : 0.0;

                var response = new OccupancyReportResponse(
                    Summary: new OccupancySummaryDto(
                        TotalBins: totalBins,
                        OccupiedBins: occupiedBins,
                        VacantBins: vacantBins,
                        OccupancyRate: Math.Round(occupancyRate, 2)
                    ),
                    Bins: binData
                );

                return TypedResults.Ok(response);
            })
            .WithName("GetWarehouseOccupancyReport")
            .WithSummary("Get warehouse bin occupancy statistics")
            .Produces<OccupancyReportResponse>(StatusCodes.Status200OK);

            return group;
        }
    }
}