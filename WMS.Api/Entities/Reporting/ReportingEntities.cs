using WMS.Api.Entities.Common;

namespace WMS.Api.Entities.Reporting
{
    public class ReportJob : AuditableEntity
    {
        public string JobNumber { get; set; } = null!;
        public ReportType ReportType { get; set; }
        public ReportFormat Format { get; set; }
        public ReportStatus Status { get; set; } = ReportStatus.Pending;
        public DateTimeOffset? PeriodStart { get; set; }
        public DateTimeOffset? PeriodEnd { get; set; }
        public string RequestedBy { get; set; } = null!;
        public string? FilePath { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }

        public int? WarehouseId { get; set; }

        public Warehouse? Warehouse { get; set; } = null!;
    }
}
