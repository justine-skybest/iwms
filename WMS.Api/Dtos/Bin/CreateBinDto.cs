using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record CreateBinDto(
    int? WarehouseId,      // Provided directly if standalone bin
    int? RackId,           // Null for standalone
    int? BayId,            // Null for standalone
    int? LevelId,          // Null for standalone
    int BinNamesId,
    int BinHashCode,
    DateTime DateAdded,
    Location3DDto? Location3D,
    float RelativeX = 0f,
    float RelativeY = 0f,
    float RelativeZ = 0f
);