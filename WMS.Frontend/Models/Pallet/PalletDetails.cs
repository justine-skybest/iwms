using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class PalletDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]    
    public string? WarehouseId {get;set;}
    
    public int PalletNumber {get; set;}

    public int PalletHashCode {get; set;}
    
    public string? PalletDimension {get;set;}

    public decimal CapacityInKG {get;set;}

    public decimal CapacityInCBM {get;set;}
        
    public DateTime DateAdded {get; set;}
}
