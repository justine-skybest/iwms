using System;

namespace WMS.Api.Dtos.ManualPicking.PickedProduct;

public record class PickedProductSummaryDto
(
    int id,
    string Name,
    int QuantityPicked,
    DateTime DatePicked
);