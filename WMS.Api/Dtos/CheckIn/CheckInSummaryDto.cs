using System;
using WMS.Api.Dtos.Bin;
using WMS.Api.Dtos.Receiving;

namespace WMS.Api.Dtos.CheckIn;

public record class CheckInSummaryDto
(
    int Id,    
    string CheckInType,
    List<BinSummaryDto> Bins,
    string PalletNumber,
    List<ReceivedProductSummaryDto> ReceivedProducts,
    DateTime CheckInDate,
    string? Notes
);
