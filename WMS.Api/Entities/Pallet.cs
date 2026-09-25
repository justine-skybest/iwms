using System;

namespace WMS.Api.Entities;

public class Pallet
{
    public int Id {get;set;}

    public int WarehouseId {get; set;}

    public Warehouse? Warehouse {get;set;}
    
    public int PalletNumber {get; set;}

    public int PalletHashCode { get; set; }

    public string? PalletDimension {get; set;}

    public decimal CapacityInKG {get;set;}
    
    public decimal CapacityInCBM {get;set;}  

    public DateTime DateAdded {get; set;}

    public ICollection<ReceivedProduct>? ReceivedProducts { get; set; }

    public ICollection<CheckIn>? CheckIns { get; set; }
}
