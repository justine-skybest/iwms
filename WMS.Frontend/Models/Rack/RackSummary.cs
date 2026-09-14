namespace WMS.Frontend.Models;

public class RackSummary
{
    public int Id { get; set; }
    
    public required string Name { get; set; }

    public required string Warehouse { get; set; }
    
    public required string Bay { get; set; }

    public required string Level { get; set; }
    
    public virtual ICollection<RackFloorMapObjectDetails>? RackFloorMapObject { get; set; } 
    
    public DateTime DateAdded { get; set; }
}
