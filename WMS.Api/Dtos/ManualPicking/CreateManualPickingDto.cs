using System;
using WMS.Api.Dtos.ManualPicking.PickedProduct;

namespace WMS.Api.Dtos.ManualPicking;

public record class CreateManualPickingDto(    
    int WarehouseId,
    int BinId,
    int CheckInId,
    List<PickedProductDetailsDto>? PickedProducts,
    DateTime PickingDate,
    string? Notes
);
