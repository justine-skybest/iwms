using WMS.Api.Dtos.Receiving;

namespace WMS.Api.Dtos.CheckIn;

public record class CheckInDetailsDto(    
    int Id,    
    string CheckInType,
    List<int> BinIds,
    int? PalletId,
    List<int>? ReceivedProductIds,
    DateTime CheckInDate,
    string? Notes
);