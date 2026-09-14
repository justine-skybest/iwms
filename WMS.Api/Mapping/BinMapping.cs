using WMS.Api.Dtos.Bin;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class BinMapping
{
    public static Bin ToEntity(this CreateBinDto bin)
    {
        return new()
        {
            RackId = bin.RackId,
            BayId = bin.BayId,
            LevelId = bin.LevelId,
            BinNamesId = bin.BinId,
            BinHashCode = bin.BinHashCode,
            DateAdded = bin.DateAdded
        };
    }

    public static Bin ToEntity(this UpdateBinDto bin, int id)
    {
        return new()
        {
            Id = id,
            RackId = bin.RackId,
            BayId = bin.BayId,
            LevelId = bin.LevelId,
            BinNamesId = bin.BinId,
            BinHashCode = bin.BinHashCode,
            DateAdded = bin.DateAdded
        };
    }

    public static BinDetailsDto ToDetailsDto(this Bin bin)
    {
        return new(
            bin.Id,
            bin.RackId,
            bin.BayId,
            bin.LevelId,
            bin.BinNamesId,
            bin.BinHashCode,
            bin.DateAdded
        );
    }

    public static BinSummaryDto ToSummaryDto(this Bin bin)
    {
        return new(
            bin.Id,
            bin.Rack!.Warehouse!.Name,
            bin.Rack!.Name,
            bin.Bay!.BayNumber.ToString(),
            bin.Level!.LevelNumber.ToString(),
            bin.BinNames!.BinName,
            bin.BinHashCode.ToString(),
            bin.DateAdded
        );
    }
    
    public static BinMovementHistoryDto ToMovementHistoryDto(this CheckIn ci)
    {
        string checkInMode;

        if (ci.PalletId != null || ci.ReceivedProducts.Any(rp => rp.PalletId != null))
        {
            checkInMode = "Palletized";
        }
        else if (ci.ReceivedProducts.Any(rp => !string.IsNullOrWhiteSpace(rp.ContainerName)))
        {
            var containerNames = ci.ReceivedProducts
                .Select(rp => rp.ContainerName)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .Distinct();

            checkInMode = "Boxed: " + string.Join(", ", containerNames);
        }
        else
        {
            checkInMode = "Loose";
        }

        return new BinMovementHistoryDto(
            MovementType: "Checked In",
            MovementId: ci.Id,
            Date: ci.CheckInDate,
            PalletNumber: ci.Pallet?.PalletNumber != null ? $"Pallet #{ci.Pallet.PalletNumber}" : null,
            Products: ci.ReceivedProducts.Select(rp => new ProductMovementDto(
                ReceivingSeries: rp!.Receiving!.Series,
                ReceivedProductId: rp.Id,
                Name: rp.Product?.Name ?? "",
                QuantityPicked: 0,
                QuantityLeft: rp.Quantity,
                Remarks: rp.Remarks,
                Shipper: rp!.Receiving!.Shipper)).ToList(),
            Notes: ci.Notes,
            CheckInMode: checkInMode
        );
    }

    public static BinMovementHistoryDto ToMovementHistoryDto(this ManualPicking mp, Dictionary<int, int> cumulativePicked)
    {
        var palletNumber = mp.CheckIn?.Pallet?.PalletNumber > 0 ? $"Pallet #{mp.CheckIn.Pallet.PalletNumber}" : null;

        var products = mp.PickedProducts.Select(pp =>
        {
            var rp = pp.ReceivedProduct!;
            var productName = rp.Product?.Name ?? "";

            // Total quantity picked so far (before this movement)
            cumulativePicked.TryGetValue(rp.Id, out int previousPicked);

            int newTotalPicked = previousPicked + pp.QuantityPicked;
            int remainingQty = rp.Quantity - newTotalPicked;

            // Update cumulative picked quantity
            cumulativePicked[rp.Id] = newTotalPicked;

            return new ProductMovementDto(
                ReceivingSeries: rp!.Receiving!.Series,
                ReceivedProductId: rp.Id,
                Name: productName,
                QuantityPicked: pp.QuantityPicked,
                QuantityLeft: Math.Max(remainingQty, 0),
                Remarks: rp.Remarks,
                Shipper: rp!.Receiving!.Shipper
            );
        }).ToList();

        return new BinMovementHistoryDto(
            MovementType: "Manual Picking",
            MovementId: mp.Id,
            Date: mp.PickingDate,
            PalletNumber: palletNumber, // Could include pallet if needed
            Products: products,
            Notes: mp.Notes,
            CheckInMode: null
        );
    }
}
