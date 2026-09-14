using System;

namespace WMS.Api.Dtos.Pallet;

public record class PalletDetailsDto
(
    int Id,
    int WarehouseId,
    int PalletNumber,
    int PalletHashCode,
    string PalletDimension,
    decimal CapacityInKG,
    decimal CapacityInCBM,
    DateTime DateAdded
);