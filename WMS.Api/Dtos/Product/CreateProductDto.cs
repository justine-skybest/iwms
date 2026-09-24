using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Product;

public record class CreateProductDto
(
    [Required][StringLength(150)] string Name,
    [Required][StringLength(150)] string Code,
    [Required][StringLength(50)] string TypeOfPackage,
    [Required][StringLength(50)] string Measurement,
    [Required] decimal Weight,
    DateTime DateAdded
);
