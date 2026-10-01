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
        public string Category { get; set; } = string.Empty;   // "Identity", "Receiving", "Import", "Inventory"
        public string Action { get; set; } = string.Empty;     // "Login", "ExcelImport", "CreateReceiving", "DeleteIncoming"

        // NARRATIVE & CONTEXT
        public string Description { get; set; } = string.Empty; // "User A performed an incoming import with 45 items"
        public string? DetailsJson { get; set; }                // Rich JSON snapshot (e.g., list of imported product names & quantities)

        // WHEN
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; } = 200;
    }
}