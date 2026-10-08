using WMS.Api.Entities;

namespace WMS.Api.Dtos.Incoming
{

    public class IncomingDocumentResponseDto
    {
        public int Id { get; set; }
        public int IncomingId { get; set; }
        public int Version { get; set; }
        public string OriginalFileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string? ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }
    }
    public record IncomingResponseDto
    {
        public int Id { get; init; }
        public int WarehouseId { get; init; }
        public string? WarehouseName { get; init; }
        public required string Shipper { get; init; }
        public string? Consignee { get; init; }
        public IncomingStatus Status { get; init; }

        public int CurrentVersion { get; set; }
        public List<IncomingDocumentResponseDto> Documents { get; set; } = new();
        public List<IncomingProductResponseDto> Products { get; init; } = new();
    }
}
