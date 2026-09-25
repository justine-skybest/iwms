using WMS.Api.Interfaces;

namespace WMS.Api.Entities
{
    public class IncomingProduct : IProductBase
    {
        public int IncomingId { get; set; }
        public Incoming? Incoming { get; set; }
        public bool Received { get; set; } = false;
    }
}
