using System;

namespace WMS.Frontend.Models;

public class PalletSummary
{
    public int Id { get; set; }
    
    public string? Warehouse {get;set;}
    
    public int PalletNumber {get; set;}

    public int PalletHashCode {get; set;}
    
    public string? PalletDimension {get;set;}

    public decimal CapacityInKG {get;set;}

    public decimal CapacityInCBM {get;set;}
        
    public DateTime DateAdded {get; set;}
}
