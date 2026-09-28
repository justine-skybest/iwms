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

                // Step 1: Execute SQL Query with pure navigation properties (No C# ternary or Enumerable.Empty inside .Select)
                var rawBinData = await query
                    .Select(bin => new
                    {
                        bin.Id,
                        BinName = bin.BinNames != null ? bin.BinNames.BinName : null,
                        bin.RackId,
                        RackName = bin.Rack != null ? bin.Rack.Name : null,
                        BayNumber = bin.Bay != null ? (int?)bin.Bay.BayNumber : null,
                        LevelNumber = bin.Level != null ? (int?)bin.Level.LevelNumber : null,
                        IsOccupied = bin.CheckIns.Any(),
                        CheckIns = bin.CheckIns.Select(ci => new
                        {
                            ci.Id,
                            ci.CheckInType,
                            ci.CheckInDate,
                            ci.PalletId,
                            ci.Notes,
                            // Direct Unpalletized Products
                            DirectProducts = ci.ReceivedProducts.Select(rp => new CheckInProductDto(
                                rp.ReceivingId,
                                rp.ExpectedProductName,
                                rp.ExpectedQuantity,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            )).ToList(),
                            // Palletized Products (EF Core translates ci.Pallet.ReceivedProducts to a LEFT JOIN automatically)
                            PalletProducts = ci.Pallet.ReceivedProducts.Select(rp => new CheckInProductDto(
                                rp.ReceivingId,
                                rp.ExpectedProductName,
                                rp.ExpectedQuantity,
                                rp.LotNumber,
                                rp.ContainerName,
                                rp.ExpectedExpirationDate
                            )).ToList()
                        }).ToList()
                    })
                    .ToListAsync(cancellationToken);

                // Step 2: Combine direct products and palletized products cleanly in C# memory
                var binData = rawBinData.Select(bin => new BinOccupancyDto(
                    bin.Id,
                    bin.BinName,
                    bin.RackId,
                    bin.RackName,
                    bin.BayNumber,
                    bin.LevelNumber,
                    bin.IsOccupied,
                    bin.CheckIns.Select(ci => new BinCheckInDto(
                        ci.Id,
                        ci.CheckInType,
                        ci.CheckInDate,
                        ci.PalletId,
                        ci.Notes,
                        ci.DirectProducts.Concat(ci.PalletProducts).ToList()
                    )).ToList()
                )).ToList();

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

            return group;
        }
    }
}