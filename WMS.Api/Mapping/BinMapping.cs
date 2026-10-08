using WMS.Api.Dtos.Bin;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class BinMapping
{
    public static Bin ToEntity(this CreateBinDto bin)
    {
        return new()
        {
            WarehouseId = bin.WarehouseId,
            RackId = bin.RackId,
            BayId = bin.BayId,
            LevelId = bin.LevelId,
            BinNamesId = bin.BinNamesId,
            BinHashCode = bin.BinHashCode,
            DateAdded = bin.DateAdded == default ? DateTime.UtcNow : bin.DateAdded,
            RelativeX = bin.RelativeX,
            RelativeY = bin.RelativeY,
            RelativeZ = bin.RelativeZ,
            Location3D = bin.Location3D is null ? null : new Location3D
            {
                PositionX = bin.Location3D.PositionX,
                PositionY = bin.Location3D.PositionY,
                PositionZ = bin.Location3D.PositionZ,
                RotationY = bin.Location3D.RotationY,
                Width = bin.Location3D.Width,
                Height = bin.Location3D.Height,
                Depth = bin.Location3D.Depth
            }
        };
    }

    public static Bin ToEntity(this UpdateBinDto bin, int id)
    {
        return new()
        {
            Id = id,
            WarehouseId = bin.WarehouseId,
            RackId = bin.RackId,
            BayId = bin.BayId,
            LevelId = bin.LevelId,
            BinNamesId = bin.BinNamesId,
            BinHashCode = bin.BinHashCode,
            DateAdded = bin.DateAdded,
            RelativeX = bin.RelativeX,
            RelativeY = bin.RelativeY,
            RelativeZ = bin.RelativeZ,
            Location3D = bin.Location3D is null ? null : new Location3D
            {
                PositionX = bin.Location3D.PositionX,
                PositionY = bin.Location3D.PositionY,
                PositionZ = bin.Location3D.PositionZ,
                RotationY = bin.Location3D.RotationY,
                Width = bin.Location3D.Width,
                Height = bin.Location3D.Height,
                Depth = bin.Location3D.Depth
            }
        };
    }

    public static BinDetailsDto ToDetailsDto(this Bin bin)
    {
        return new(
            bin.Id,
            bin.WarehouseId,
            bin.RackId,
            bin.BayId,
            bin.LevelId,
            bin.BinNamesId,
            bin.BinHashCode,
            bin.DateAdded,
            bin.Location3D is null ? null : new Location3DDto(
                bin.Location3D.PositionX,
                bin.Location3D.PositionY,
                bin.Location3D.PositionZ,
                bin.Location3D.RotationY,
                bin.Location3D.Width,
                bin.Location3D.Height,
                bin.Location3D.Depth
            ),
            bin.RelativeX ?? 0f,
            bin.RelativeY ?? 0f,
            bin.RelativeZ ?? 0f
        );
    }

    public static BinSummaryDto ToSummaryDto(this Bin bin)
    {
        return new(
            bin.Id,
            bin.Rack?.Warehouse?.Name ?? bin.Warehouse?.Name ?? "N/A",
            bin.Rack?.Name ?? "Standalone",
            bin.Bay?.BayNumber.ToString() ?? "N/A",
            bin.Level?.LevelNumber.ToString() ?? "N/A",
            bin.BinNames?.BinName ?? "Unassigned",
            bin.BinHashCode.ToString(),
            bin.DateAdded,
            bin.Location3D is null ? null : new Location3DDto(
                bin.Location3D.PositionX,
                bin.Location3D.PositionY,
                bin.Location3D.PositionZ,
                bin.Location3D.RotationY,
                bin.Location3D.Width,
                bin.Location3D.Height,
                bin.Location3D.Depth
            ),
            bin.RelativeX ?? 0f,
            bin.RelativeY ?? 0f,
            bin.RelativeZ ?? 0f
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
            PalletNumber: palletNumber,
            Products: products,
            Notes: mp.Notes,
            CheckInMode: null
        );
    }
}