using WMS.Api.Interfaces;

namespace WMS.Api.Entities
{
    public enum IncomingProductStatus
    {
        UNRECEIVED = 1,
        PARTIAL,
        RECEIVED,
        CLOSED_SHORT
    }
    public class IncomingProduct : IProductBase
    {
        public int IncomingId { get; set; }
        public Incoming? Incoming { get; set; }
        public IncomingProductStatus Status { get; set; } = IncomingProductStatus.UNRECEIVED;
        public DateTime? DateAdded { get; set; } = null;
    }
}
