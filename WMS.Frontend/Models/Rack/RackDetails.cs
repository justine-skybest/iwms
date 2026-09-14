using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class RackDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]    
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "The Warehouse field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? WarehouseId { get; set; }

    [Required(ErrorMessage = "The Bay field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? BayId { get; set; }

    [Required(ErrorMessage = "The Level field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? LevelId { get; set; }
    
    public bool IsFloorDocking { get; set; }

    public virtual ICollection<RackFloorMapObjectDetails>? RackFloorMapObject { get; set; } 

    public DateTime DateAdded { get; set; }
}
