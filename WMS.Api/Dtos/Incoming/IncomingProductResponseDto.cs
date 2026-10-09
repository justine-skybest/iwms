using WMS.Api.Entities;

namespace WMS.Api.Dtos.Incoming
{
    public record IncomingProductResponseDto
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public string? ProductName { get; init; }
        public string? Code { get; init; }
        public decimal? UnitPrice { get; init; }
        public decimal? TotalAmount { get; init; }
        public int Quantity { get; init; }           // Total planned quantity
        public int ReceivedQuantity { get; init; }   // Quantity already received across linked receipts
        public int RemainingQuantity { get; init; }  // Balance remaining to receive
        public required decimal CBM { get; init; }
        public decimal TotalCbm { get; set; }
        public required string TotalWeight { get; init; }

        public string? TypeOfPackage { get; set; }
        public DateOnly? ExpirationDate { get; init; }
        public string? Supplier { get; init; }
        public IncomingProductStatus Status { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? Remarks { get; init; }
    }
}
