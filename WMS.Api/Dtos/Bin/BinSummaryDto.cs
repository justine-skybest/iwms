using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record BinSummaryDto(
    int Id,
    string Warehouse,
    string Rack,
    string Bay,
    string Level,
    string BinName,
    string BinHashCode,
    DateTime DateAdded,
    Location3DDto? Location3D = null,
    float RelativeX = 0f,
    float RelativeY = 0f,
    float RelativeZ = 0f
);