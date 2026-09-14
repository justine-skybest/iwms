using System;
using WMS.Api.Dtos.Pallet;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class PalletMapping
{
    public static Pallet ToEntity(this CreatePalletDto createdPallet)
    {
        return new Pallet(){
            WarehouseId = createdPallet.WarehouseId,
            PalletNumber = createdPallet.PalletNumber,
            PalletHashCode = createdPallet.PalletHashCode,
            PalletDimension = createdPallet.PalletDimension,
            CapacityInKG = createdPallet.CapacityInKG,
            CapacityInCBM = createdPallet.CapacityInCBM,
            DateAdded = createdPallet.DateAdded
        };
    }

    public static Pallet ToUpdateEntity(this CreatePalletDto createdPallet, int id)
    {
        return new()
        {
            Id = id,
            WarehouseId = createdPallet.WarehouseId,
            PalletNumber = createdPallet.PalletNumber,
            PalletHashCode = createdPallet.PalletHashCode,
            PalletDimension = createdPallet.PalletDimension,
            CapacityInKG = createdPallet.CapacityInKG,
            CapacityInCBM = createdPallet.CapacityInCBM,
            DateAdded = createdPallet.DateAdded
        };
    }

    public static PalletSummaryDto ToSummaryDto(this Pallet pallet)
    {
        return new PalletSummaryDto(
            pallet.Id,
            pallet.Warehouse!.Name,
            pallet.PalletNumber,
            pallet.PalletHashCode,
            pallet.PalletDimension ?? "",
            pallet.CapacityInKG,
            pallet.CapacityInCBM,
            pallet.DateAdded
        );
    }

    public static PalletDetailsDto ToDetailDto(this Pallet pallet)
    {
        return new PalletDetailsDto(
            pallet.Id,
            pallet.WarehouseId,
            pallet.PalletNumber,
            pallet.PalletHashCode,
            pallet.PalletDimension ?? "",
            pallet.CapacityInKG,
            pallet.CapacityInCBM,
            pallet.DateAdded
        );
    }

    public static PalletToBeCheckInDto ToBeCheckInDto(this Pallet pallet)
    {
        return new PalletToBeCheckInDto(
            pallet.Id,
            pallet.WarehouseId,
            pallet.Warehouse!.Name,
            pallet.PalletNumber != 0 ? $"Pallet #{pallet.PalletNumber}" : "",
            pallet.PalletHashCode,
            pallet.PalletDimension ?? "",
            pallet.CapacityInKG,
            pallet.CapacityInCBM,
            pallet.ReceivedProducts!.Select(product => product.ToReceivedProductDTO()).ToList()
        );
    }
}
