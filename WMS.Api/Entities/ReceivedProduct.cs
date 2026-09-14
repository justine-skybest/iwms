using System;

namespace WMS.Api.Entities;

public class ReceivedProduct
{
    public int Id { get; set; }

    public int ReceivingId { get; set; }
    
    public Receiving? Receiving { get; set; }

    public int ProductId { get; set; }

    public Product? Product { get; set; }
    
    public int Quantity {get;set;}

    public required string CBM {get; set;}

    public required string TotalWeight {get; set;}

    public DateOnly ExpirationDate { get; set; }

    public required string Remarks {get;set;}

    public required string ContainerName {get;set;}

    public int? PalletId {get; set;}

    public Pallet? Pallet {get;set;}

    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
}
