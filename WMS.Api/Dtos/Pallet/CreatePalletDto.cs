using System;

namespace WMS.Api.Dtos.Pallet;

public record class CreatePalletDto
(
    int WarehouseId,
    int PalletNumber,
    int PalletHashCode,
    string PalletDimension,
    decimal CapacityInKG,
    decimal CapacityInCBM,
    DateTime DateAdded
);
