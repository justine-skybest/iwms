namespace WMS.Api.Entities
{
    public class IncomingDocument
    {
        public int Id { get; set; }
        public int IncomingId { get; set; }
        public Incoming? Incoming { get; set; }

        public int Version { get; set; } // 1 for initial, 2 for first revision, etc.
        public required string OriginalFileName { get; set; }
        public required string FilePath { get; set; } // The physical path on the server/storage
        public string? ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}