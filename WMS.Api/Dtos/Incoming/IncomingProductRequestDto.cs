using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Incoming
{
    public record IncomingProductRequestDto
    {
        [Required]
        public int ProductId { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; init; }

        public required string CBM { get; init; }

        public required string TotalWeight { get; init; }

        public DateOnly? ExpirationDate { get; init; }

        public string? Remarks { get; init; }
    }
}
