using System.ComponentModel.DataAnnotations;

namespace WMS.Frontend.Models;

public class WarehouseDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required]
    [StringLength(150)]
    public required string Address {get; set;}
    
    public byte[]? FloorPlanImage {get; set;}
    
    public DateTime DateAdded {get; set;}
}
