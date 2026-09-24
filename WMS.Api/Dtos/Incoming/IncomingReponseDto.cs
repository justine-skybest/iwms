using WMS.Api.Entities;

namespace WMS.Api.Dtos.Incoming
{
    public record IncomingResponseDto
    {
        public int Id { get; init; }
        public int WarehouseId { get; init; }
        public string? WarehouseName { get; init; }
        public required string Shipper { get; init; }
        public string? Consignee { get; init; }
        public IncomingStatus Status { get; init; }
        public List<IncomingProductResponseDto> Products { get; init; } = new();
    }
}
