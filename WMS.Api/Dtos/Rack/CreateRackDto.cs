using System.ComponentModel.DataAnnotations;
using WMS.Api.Entities;

namespace WMS.Api.Dtos;

public record class CreateRackDto
(
    [Required][StringLength(50)] string Name,
    int WarehouseId,    
    int BayId,
    int LevelId,
    ICollection<RackFloorMapObjectDetails> RackFloorMapObject,
    bool IsFloorDocking,
    DateTime DateAdded
);
    

