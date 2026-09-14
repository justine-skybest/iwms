using System;

namespace WMS.Api.Dtos.CheckIn;

public record class CreateCheckInDto(        
    string CheckInType,
    List<int> BinIds,
    int? PalletId,
    List<int>? ReceivedProductIds,
    DateTime CheckInDate,
    string? Notes
);