using System;

namespace WMS.Frontend.Models;

public class CheckedInProductSummary
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? TypeOfPackage { get; set; }

    public string? Measurement { get; set; }

    public decimal Weight { get; set; }

    public int Quantity { get; set; }

    public required string CBM { get; set; }

    public required string TotalWeight { get; set; }

    public required DateOnly ExpirationDate { get; set; }

    public required string Remarks { get; set; }

    public required string ContainerName { get; set; }

    public required string PalletId { get; set; }

    public required string ReceivingSeries { get; set; }
    
    public required string Shipper { get; set; }
}
