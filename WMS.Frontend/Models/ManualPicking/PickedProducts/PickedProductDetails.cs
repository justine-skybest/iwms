using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class PickedProductDetails
{
    [Required(ErrorMessage = "The Product field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? ReceivedProductId { get; set; }

    public int QuantityPicked { get; set; }

    public DateTime DatePicked {get;set;}
}
