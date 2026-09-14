using System;

namespace WMS.Frontend.Models;

public class BinSummary
{
    
    public int Id { get; set; }

    public required string Warehouse {get; set;}
    
    public required string Rack { get; set; }

    public required string Bay { get; set; }

    public required string Level { get; set; }

    public required string BinName { get; set; }

    public required string BinHashCode { get; set; }

    public DateTime DateAdded { get; set; }
}
