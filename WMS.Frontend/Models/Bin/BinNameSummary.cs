using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class BinNameSummary
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Bin field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public required string BinName { get; set; }
}
