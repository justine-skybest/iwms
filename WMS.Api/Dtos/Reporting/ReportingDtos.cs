using WMS.Api.Entities.Reporting;

namespace WMS.Api.Dtos.Reporting
{
    public record GenerateReceivingReportRequest(
        ReceivingReportSubType SubType,
        ReportFormat Format,
        DateTime? StartDate,
        DateTime? EndDate,
        int? IncomingId,
        string? PackingListNumber,
        string? PlateNumber,
        string? PalletNumber,
        int? WarehouseId,
        string? Supplier
    );

    public record GenerateReportResponse(
        string Message,
        int JobId,
        string JobNumber
    );
}
