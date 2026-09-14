using System;
using WMS.Api.Dtos.Receiving;

namespace WMS.Api.Dtos.Pallet;

public record class PalletToBeCheckInDto
(
    int Id,
    int WarehouseId,
    string Warehouse,
    string PalletNumber,
    int PalletHashCode,
    string PalletDimension,
    decimal CapacityInKG,
    decimal CapacityInCBM,    
    List<ToCheckInProducts> ReceivedProducts
);