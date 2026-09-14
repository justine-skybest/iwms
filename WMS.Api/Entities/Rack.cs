using System;

namespace WMS.Api.Entities;

public class Rack
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public int WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public int BayId {get; set;}

    public Bay? Bay {get; set;}

    public int LevelId {get; set;}

    public Level? Level { get; set; }
    
    public required bool IsFloorDocking {get; set;}

    public DateTime DateAdded { get; set; }    

    public virtual required ICollection<RackFloorMapObject> RackFloorMapObject { get; set; } 
}
