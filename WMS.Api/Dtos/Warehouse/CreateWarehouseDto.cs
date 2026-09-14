using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos;

public record class  CreateWarehouseDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(150)] string Address,
    byte[] FloorPlanImage,
    DateTime DateAdded
);