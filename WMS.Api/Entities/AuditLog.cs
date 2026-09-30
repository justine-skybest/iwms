namespace WMS.Api.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? TraceId { get; set; }

        // WHO
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserRole { get; set; }
        public string? IpAddress { get; set; }

        // WHAT
        public string EntityName { get; set; } = string.Empty; // e.g. "Product", "Warehouse"
        public string Action { get; set; } = string.Empty;     // "Added", "Modified", "Deleted"
        public string PrimaryKey { get; set; } = string.Empty; // e.g. Entity ID
        public string? OldValues { get; set; }                 // JSON of changed properties before update
        public string? NewValues { get; set; }                 // JSON of changed properties after update

        // WHEN
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // RESULT
        public int StatusCode { get; set; }
        public long ExecutionTimeMs { get; set; }
    }
}
