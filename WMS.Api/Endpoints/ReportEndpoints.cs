using Microsoft.AspNetCore.Http;
using WMS.Api.Endpoints.ReportsEndpoints;
using WMS.Api.Entities.Reporting;

namespace WMS.Api.Endpoints
{
    public record GenerateReportResponse(
        string Message,
        int JobId,
        string JobNumber
    );

    public record ReportListResponse(
        List<ReportJob> Items,
        int Page,
        int PageSize,
        int TotalCount,
        int TotalPages
    );

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
        int? RackId,
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

            // Delegate endpoints to dedicated domain classes
            group.MapReceivingReportEndpoints();
            group.MapPickOrderReportEndpoints();
            group.MapOccupancyReportEndpoints();
            group.MapInventoryAgingReportEndpoints();

            return group;
        }
    }
}