using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class ReceivedProductDetails
{
    public int Id { get; set; }
    
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "The Quantity must be a whole number.")]
    
     public int Quantity {get;set;}

    public required string CBM {get; set;}

    public required string TotalWeight {get; set;}

    public required DateOnly ExpirationDate {get; set;}

    public required string Remarks {get;set;}

    public string? ContainerName {get;set;}

    [JsonConverter(typeof(StringConverter))]
    public string? PalletId {get; set;}
}
