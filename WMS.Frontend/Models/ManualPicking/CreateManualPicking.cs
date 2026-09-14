using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class CreateManualPicking
{

    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? WarehouseId { get; set; }
    
    [Required(ErrorMessage = "The Bin field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? BinId { get; set; }
    
    [Required(ErrorMessage = "The Check-in field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? CheckInId { get; set; }

    public List<PickedProductDetails>? PickedProducts { get; set; }

    public DateTime PickingDate {get;set;}

    public string? Notes {get;set;}    
}   
