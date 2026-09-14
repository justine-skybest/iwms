using System;

namespace WMS.Api.Dtos.ManualPicking.PickedProduct;

public record class PickedProductDetailsDto
(
    int ReceivedProductId,
    int QuantityPicked,
    DateTime DatePicked
);