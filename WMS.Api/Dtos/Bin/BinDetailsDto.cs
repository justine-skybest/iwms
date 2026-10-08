using System;

namespace WMS.Api.Dtos.Bin;

public record class BinDetailsDto(
    int Id,
    int? WarehouseId,
    int? RackId,
    int? BayId,
    int? LevelId,
    int BinNamesId,
    int BinHashCode,
    DateTime DateAdded,
    Location3DDto? Location3D = null,
    float RelativeX = 0f,
    float RelativeY = 0f,
    float RelativeZ = 0f
);