using System;
using WMS.Api.Dtos.ManualPicking.PickedProduct;

namespace WMS.Api.Dtos.ManualPicking;

/// <summary>Detailed manual-picking information, including its picked-product lines.</summary>
public record class ManualPickingDetailsDto(
    int Id,
    int WarehouseId,
    int BinId,
    List<int>? PickedProductIds,
    DateTime PickingDate,
    string? Notes,
    List<PickedProductSummaryDto> PickProducts
);
