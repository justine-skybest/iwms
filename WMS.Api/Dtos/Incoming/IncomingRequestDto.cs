using System.ComponentModel.DataAnnotations;
using WMS.Api.Entities;

namespace WMS.Api.Dtos.Incoming
{
    public record IncomingRequestDto
    {
        [Required]
        public int WarehouseId { get; init; }

        public required string Shipper { get; init; }

        public string? Consignee { get; init; }

        public IncomingStatus Status { get; init; } = IncomingStatus.PENDING;

        [Required]
        [MinLength(1, ErrorMessage = "At least one product must be included.")]
        public required List<IncomingProductRequestDto> Products { get; init; } = new();
    }
}
