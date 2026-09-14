using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class BinDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? WarehouseId { get; set; }

    [Required(ErrorMessage = "The Rack field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? RackId { get; set; }

    [Required(ErrorMessage = "The Bay field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? BayId { get; set; }

    [Required(ErrorMessage = "The Level field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? LevelId { get; set; }

    [Required(ErrorMessage = "The Bin field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? BinId { get; set; }

    public int BinHashCode {get; set;}

    public DateTime DateAdded { get; set; }

}
