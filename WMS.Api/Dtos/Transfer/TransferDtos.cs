using System;

namespace WMS.Api.Dtos.Transfer;

public record class PalletLocationDto(
    int PalletId,
    int WarehouseId,
    int PalletNumber,
    int PalletHashCode,
    int? CheckInId,
    int? CurrentBinId,
    string? CurrentBinLocation,
    string? Message
);

public record class TransferPalletDto(
    int PalletId,
    int ToBinId,
    string? Notes
);

public record class ItemLocationSummaryDto(
    int ReceivedProductId,
    int CheckInId,
    string ProductName,
    string TypeOfPackage,
    int Quantity,
    string ReceivingSeries
);

public record class TransferItemDto(
    int ReceivedProductId,
    int FromCheckInId,
    int ToBinId,
    string? Notes
);

public record class TransferResultDto(
    bool Success,
    string Message
);

public record class TransferLogDto(
    int Id,
    string TransferType,
    string ItemDescription,
    string FromBinLocation,
    string ToBinLocation,
    DateTime TransferDate,
    string? Notes
);
