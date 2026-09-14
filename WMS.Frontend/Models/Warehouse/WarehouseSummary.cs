using System;

namespace WMS.Frontend.Models;

public class WarehouseSummary
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Address {get; set;}

    public byte[]? FloorPlanImage {get; set;}
    
    public DateTime DateAdded {get; set;}
}
