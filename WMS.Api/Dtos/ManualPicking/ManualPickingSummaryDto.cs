using System;
using WMS.Api.Dtos.ManualPicking.PickedProduct;

namespace WMS.Api.Dtos.ManualPicking;

public record class ManualPickingSummaryDto
(
    int Id,    
    string Warehouse,
    string Bin,
    List<PickedProductSummaryDto> PickProducts,
    DateTime PickingDate,
    string? Notes
);
