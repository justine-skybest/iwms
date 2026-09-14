using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record class UpdateBinDto
(
    int RackId,
    int BayId,
    int LevelId,
    int BinId,
    int BinHashCode,
    DateTime DateAdded
);