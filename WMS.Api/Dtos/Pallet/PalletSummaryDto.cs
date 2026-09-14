using System;

namespace WMS.Api.Dtos.Pallet;

public record class PalletSummaryDto
(
    int Id,
    string Warehouse,
    int PalletNumber,
    int PalletHashCode,
    string PalletDimension,
    decimal CapacityInKG,
    decimal CapacityInCBM,
    DateTime DateAdded
);