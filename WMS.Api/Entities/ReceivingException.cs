namespace WMS.Api.Entities
{
    public class ReceivingException
    {
        public int Id { get; set; }

        // Link to the Unlisted Received Product
        public int ReceivedProductId { get; set; }
        public ReceivedProduct? ReceivedProduct { get; set; }

        public required string Reason { get; set; } // e.g. "Not included in original packing list"
        public required string DeliveryReceiptReference { get; set; }
        public required string ApprovedBy { get; set; } // Person who authorized receiving

        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // One Exception can have multiple photos
        public List<ExceptionPhoto> Photos { get; set; } = new();
    }

    public class ExceptionPhoto
    {
        public int Id { get; set; }
        public int ReceivingExceptionId { get; set; }
        public ReceivingException? ReceivingException { get; set; }

        public required string PhotoUrl { get; set; } // Path to S3/Blob storage
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
