using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record UpdateBinDto(
    int? WarehouseId,
    int? RackId,
    int? BayId,
    int? LevelId,
    int BinNamesId,
    int BinHashCode,
    DateTime DateAdded,
    Location3DDto? Location3D,
    float RelativeX = 0f,
    float RelativeY = 0f,
    float RelativeZ = 0f
);