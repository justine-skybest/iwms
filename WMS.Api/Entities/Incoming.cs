using WMS.Api.Interfaces;

namespace WMS.Api.Entities
{
    public enum IncomingStatus
    {
        PENDING = 1,
        RECEIVED,
        PARTIAL,
        CANCELLED
    }
    public class Incoming : IIncomingShipment<IncomingProduct>
    {
        // Inherits all base properties directly; no re-declarations needed
        public IncomingStatus Status { get; set; } = IncomingStatus.PENDING;
    }
}
