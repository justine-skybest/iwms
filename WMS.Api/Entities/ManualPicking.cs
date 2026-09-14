namespace WMS.Api.Entities;

public class ManualPicking
{
    public int Id { get; set; }

    public int WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public int BinId { get; set; }

    public Bin? Bin { get; set; }

    public int? CheckInId { get; set; }

    public CheckIn? CheckIn { get; set; }

    public ICollection<PickedProduct> PickedProducts { get; set; } = new List<PickedProduct>();

    public DateTime PickingDate { get; set; }

    public string? Notes { get; set; } 

}
