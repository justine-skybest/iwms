using WMS.Api.Dtos.Receiving;

namespace WMS.Api.Dtos.CheckIn;

public record class DisplayCheckInProductsDto(
    int Id,        
    string CheckInType,    
    string PalletNumber,
    List<CheckedInProductSumamryDto> ReceivedProducts,
    DateTime CheckInDate,
    string? Notes
);