using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class ReceivingDetails
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? WarehouseId {get; set;}
    [Required]
    [StringLength(15)]
    public required string Series { get; set; }
    [Required]
    [StringLength(85)] 
    public required string TransportCompany { get; set; }
    [Required]
    [StringLength(85)] 
    public required string Shipper { get; set; }
    [StringLength(85)] 
    public string? Consignee { get; set; }
    public DateTime DateReceived { get; set; }
    [Required]
    [StringLength(35)] 
    public required string Reference { get; set; }    
    [Required]
    [Length(1,100,ErrorMessage = "Atleast one product received is required.")]    
    public required List<ReceivedProductDetails> Products { get; set; }  
    [Required]
    [StringLength(85)] 
    public required string PlateNumber { get; set; }
    [Required]
    [StringLength(85)] 
    public required string DriverName { get; set; }
    public DateTime DateTime { get; set; }
    [StringLength(85)] 
    public string? ClientRepresentative { get; set; }    
    [StringLength(85)] 
    public string? CheckerName { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime TimeEnd { get; set; }
    public DateTime DateAdded { get; set; }
}
