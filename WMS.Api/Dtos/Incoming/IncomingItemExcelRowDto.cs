namespace WMS.Api.Dtos.Incoming
{
    public record class IncomingItemExcelRowDto
    {
        public int LineNumber { get; init; }
        public int Quantity { get; init; }
        public required string ProductCode { get; init; }
        public string? Uom { get; init; }
        public required string ProductDescription { get; init; }
        public decimal? UnitPrice { get; init; }
        public decimal? TotalAmount { get; init; }
        public DateOnly? ExpirationDate { get; init; }
        public string? Cbm { get; init; }
        public string? TotalCbm { get; init; }
        public string? Weight { get; init; }
        public string? TotalWeight { get; init; }
        public string? Supplier { get; init; }
        public string? Remarks { get; init; }
    }
}
