using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class BaySummary
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Level field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public required string BayNumber { get; set; }
}
