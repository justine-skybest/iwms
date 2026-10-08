using DocumentFormat.OpenXml.Spreadsheet;

namespace WMS.Api.Entities;

public class Bin
{
    public int Id { get; set; }  
    public int? WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }

    public int? RackId { get; set; }

    public Rack? Rack { get; set; }

    public int? BayId {get; set;}

    public Bay? Bay {get; set;}

    public int? LevelId {get; set;}

    public Level? Level { get; set; }

    public int BinNamesId {get; set;}

    public BinNames? BinNames {get; set;}

    public int BinHashCode { get; set; }

    public DateTime DateAdded { get; set; }

    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

    public int? StandaloneLocationId { get; set; }
    public Location3D? Location3D { get; set; }

    // Offset coordinates if bin position inside a rack is customizable
    public float? RelativeX { get; set; }
    public float? RelativeY { get; set; }
    public float? RelativeZ { get; set; }
}
