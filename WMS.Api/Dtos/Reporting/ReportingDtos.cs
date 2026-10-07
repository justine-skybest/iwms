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

    public record GeneratePickOrderReportRequest(
        ReportFormat Format,
        DateTime? StartDate,
        DateTime? EndDate,
        string? Shipper,
        int? WarehouseId
    );
    public record GenerateInventoryAgingReportRequest(
        ReportFormat Format,
        int? WarehouseId,
        string? Shipper,
        int? ProductId
    );

    public record AgingItemDto(
        string ProductCode,
        string ProductName,
        string Shipper,
        string WarehouseName,
        string Location,
        DateTime DateReceived,
        int AgeInDays,
        string AgingBucket,
        int RemainingQuantity,
        string Unit
    );

    public record GenerateReportResponse(
        string Message,
        int JobId,
        string JobNumber
    );
}
