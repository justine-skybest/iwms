using System;
using WMS.Api.Dtos.ManualPicking;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class ManualPickingMapping
{
    public static ManualPicking ToEntity(this CreateManualPickingDto manualPicking)
    {
        return new ManualPicking()
        {
            WarehouseId = manualPicking.WarehouseId,
            BinId = manualPicking.BinId,
            CheckInId = manualPicking.CheckInId,
            PickedProducts = manualPicking.PickedProducts!.Select(product => product.ToEntity()).ToList(),
            PickingDate = manualPicking.PickingDate,
            Notes = manualPicking.Notes
        };
    }

    public static ManualPickingDetailsDto ToDetailsDto(this ManualPicking picking)
    {
        return new(
            picking.Id,
            picking.WarehouseId,
            picking.BinId,
            picking.PickedProducts.Select(product => product.Id).ToList(),
            picking.PickingDate,
            picking.Notes
        );
    }
    
    public static ManualPickingSummaryDto ToSummaryDto(this ManualPicking picking)
    {
        return new(
            picking.Id,
            picking.Warehouse!.Name,
            picking.Bin!.BinNames!.BinName,
            picking.PickedProducts.Select(product => product.ToSummaryDto()).ToList(),
            picking.PickingDate,
            picking.Notes
        );
    }    
}
