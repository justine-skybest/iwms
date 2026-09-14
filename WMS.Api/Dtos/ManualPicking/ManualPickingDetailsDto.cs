using System;

namespace WMS.Api.Dtos.ManualPicking;

public record class ManualPickingDetailsDto(
    int Id,
    int WarehouseId,
    int BinId,
    List<int>? PickedProductIds,
    DateTime PickingDate,
    string? Notes
);
