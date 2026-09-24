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
        public int Quantity { get; init; }
        public required string CBM { get; init; }
        public required string TotalWeight { get; init; }
        public DateOnly? ExpirationDate { get; init; }
        public string? Supplier { get; init; }
        public string? Remarks { get; init; }
    }
}
