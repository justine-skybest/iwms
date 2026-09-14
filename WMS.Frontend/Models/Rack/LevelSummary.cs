using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class LevelSummary
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Level field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public required string LevelNumber { get; set; }
}
