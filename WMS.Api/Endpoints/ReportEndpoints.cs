using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WMS.Api.Data;

namespace WMS.Api.Endpoints
{
    public record CheckInProductDto(
        int Id,
        string? ProductName,
        int? Quantity,
        string? LotNumber,
        string? ContainerName,
        DateOnly? ExpirationDate
    );

    public record BinCheckInDto(
        int Id,
        string CheckInType,
        DateTime CheckInDate,
        int? PalletId,
        string? Notes,
        IReadOnlyCollection<CheckInProductDto> Products
    );

    public record BinOccupancyDto(
        int Id,
        string? BinName,
        int RackId,
        string? RackName,
        int? BayNumber,
        int? LevelNumber,
        bool IsOccupied,
        IReadOnlyCollection<BinCheckInDto> CheckIns
    );

    public record OccupancySummaryDto(
        int TotalBins,
        int OccupiedBins,
        int VacantBins,
        double OccupancyRate
    );

    public record OccupancyReportResponse(
        OccupancySummaryDto Summary,
        IReadOnlyCollection<BinOccupancyDto> Bins
    );

    public static class ReportEndpoints
    {
        public static RouteGroupBuilder MapReportEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/reports")
                .WithTags("Reports");

            group.MapGet("/warehouse-occupancy", async (
                WMSContext dbContext,
                int? warehouseId,
                int? rackId,
                CancellationToken cancellationToken) =>
            {
                var query = dbContext.Bins.AsNoTracking();

                if (warehouseId.HasValue)
                {
                    query = query.Where(bin => bin.Rack != null && bin.Rack.WarehouseId == warehouseId.Value);
                }

                if (rackId.HasValue)
                {
                    query = query.Where(bin => bin.RackId == rackId.Value);
                }

                // Step 1: Query raw bin data and sum total picked quantities per ReceivedProduct
                var rawBinData = await query
                    .Select(bin => new
                    {
                        bin.Id,
                        BinName = bin.BinNames != null ? bin.BinNames.BinName : null,
                        bin.RackId,
                        RackName = bin.Rack != null ? bin.Rack.Name : null,
                        BayNumber = bin.Bay != null ? (int?)bin.Bay.BayNumber : null,
                        LevelNumber = bin.Level != null ? (int?)bin.Level.LevelNumber : null,
                        CheckIns = bin.CheckIns.Select(ci => new
                        {
                            ci.Id,
                            ci.CheckInType,
                            ci.CheckInDate,
                            ci.PalletId,
                            ci.Notes,
                            // Direct Unpalletized Products
                            DirectProducts = ci.ReceivedProducts.Select(rp => new
                            {
                                rp.ReceivingId,
                                ProductName = rp.ExpectedProductName,
                                OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity : rp.Quantity,
                                PickedQuantity = dbContext.PickedProducts
                                    .Where(pp => pp.ReceivedProductId == rp.Id)
                                    .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            }).ToList(),
                            // Palletized Products (EF Core handles null Pallet automatically via LEFT JOIN)
                            PalletProducts = ci.Pallet.ReceivedProducts.Select(rp => new
                            {
                                rp.ReceivingId,
                                ProductName = rp.ExpectedProductName,
                                OriginalQuantity = rp.ExpectedQuantity > 0 ? rp.ExpectedQuantity : rp.Quantity,
                                PickedQuantity = dbContext.PickedProducts
                                    .Where(pp => pp.ReceivedProductId == rp.Id)
                                    .Sum(pp => (int?)pp.QuantityPicked) ?? 0,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            }).ToList()
                        }).ToList()
                    })
                    .ToListAsync(cancellationToken);

                // Step 2: In-memory filtering — strictly exclude 0-quantity products and empty check-ins
                // Step 2: In-memory filtering — prioritize PalletProducts over DirectProducts to prevent duplication
                var binData = rawBinData.Select(bin =>
                {
                    var activeCheckIns = bin.CheckIns.Select(ci =>
                    {
                        // 1. Pick PalletProducts if available, otherwise fall back to DirectProducts
                        var targetProducts = (ci.PalletProducts != null && ci.PalletProducts.Count > 0)
                            ? ci.PalletProducts
                            : ci.DirectProducts;

                        // 2. Deduct picked stock and exclude 0-quantity items
                        var remainingProducts = targetProducts
                            .Select(p => new
                            {
                                Product = p,
                                RemainingQuantity = p.OriginalQuantity - p.PickedQuantity
                            })
                            .Where(x => x.RemainingQuantity > 0)
                            .Select(x => new CheckInProductDto(
                                x.Product.ReceivingId,
                                x.Product.ProductName,
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
            .WithDescription("Calculates bin occupancy metrics with itemized bin check-ins and product details.")
            .Produces<OccupancyReportResponse>(StatusCodes.Status200OK);

            group.MapGet("/transaction-summary", async (
                WMSContext dbContext,
                DateTime startDate,
                DateTime endDate,
                int? warehouseId = null) =>
            {

            });

            return group;
        }
    }
}