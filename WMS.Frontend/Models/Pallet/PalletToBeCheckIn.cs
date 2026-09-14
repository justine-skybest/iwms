using System;

namespace WMS.Frontend.Models;

public class PalletToBeCheckIn
{
    public int Id { get; set; }
    
    public string? PalletNumber {get; set;}

    public int PalletHashCode {get; set;}
    
    public string? PalletDimension {get;set;}

    public decimal CapacityInKG {get;set;}

    public decimal CapacityInCBM {get;set;}
    
    public required List<ToCheckInProductSummary> ReceivedProducts {get;set;}
}
