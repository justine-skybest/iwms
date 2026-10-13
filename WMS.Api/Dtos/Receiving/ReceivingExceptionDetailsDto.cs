namespace WMS.Api.Dtos.Receiving
{
    public record class ReceivingExceptionDetailsDto
    {
        public int Id { get; set; }
        public required string Reason { get; set; }
        public required string DeliveryReceiptReference { get; set; }
        public required string ApprovedBy { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Photos { get; set; } = new();
    }
}
