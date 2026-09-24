using WMS.Api.Entities;

namespace WMS.Api.Interfaces
{
    public abstract class IIncomingShipment<TProduct>
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
        public required string Shipper { get; set; }
        public string? Consignee { get; set; }
        public required List<TProduct> Products { get; set; }
    }
}
