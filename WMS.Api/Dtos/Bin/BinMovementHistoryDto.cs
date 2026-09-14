using System;

namespace WMS.Api.Dtos.Bin;

public record BinMovementHistoryDto(
    string MovementType,
    int MovementId,
    DateTime Date,
    string? PalletNumber,
    List<ProductMovementDto> Products,
    string? Notes,
    string? CheckInMode
);

