using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class ManualPickingDetails
{
    public int Id {get;set;}    

    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? WarehouseId { get; set; }
    
    [Required(ErrorMessage = "The Bin field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? BinId { get; set; }

    public int? PalletId {get;set;}

    public List<int>? PickedProductIds { get; set; }

    public DateTime PickingDate {get;set;}

    public string? Notes {get;set;}    
}   
