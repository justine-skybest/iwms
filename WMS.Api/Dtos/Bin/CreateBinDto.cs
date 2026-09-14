using System.ComponentModel.DataAnnotations;

namespace WMS.Api.Dtos.Bin;

public record class CreateBinDto
(
    int RackId,
    int BayId,
    int LevelId,
    int BinId,
    int BinHashCode,
    DateTime DateAdded
);