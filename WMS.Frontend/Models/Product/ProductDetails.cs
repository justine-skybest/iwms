using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WMS.Frontend.Converters;

namespace WMS.Frontend.Models;

public class ProductDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "The Type of Package field is required.")]
    [StringLength(50)]
    public required string TypeOfPackage { get; set; }
    [Required]
    [StringLength(50)]
    public required string Measurement { get; set; }
    [Required]
    public decimal Weight {get;set;}
    
    public DateTime DateAdded {get; set;}
}
