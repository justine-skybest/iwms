using System;
using WMS.Api.Dtos.ManualPicking.PickedProduct;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class PickedProductMapping
{
    public static PickedProduct ToEntity(this PickedProductDetailsDto pickedProduct)
    {
        return new PickedProduct()
        {
            ReceivedProductId = pickedProduct.ReceivedProductId,
            QuantityPicked = pickedProduct.QuantityPicked,
            DatePicked = pickedProduct.DatePicked
        };
    }

     public static PickedProductSummaryDto ToSummaryDto(this PickedProduct pickedProduct)
    {
        return new PickedProductSummaryDto(
            pickedProduct.Id,
            pickedProduct!.ReceivedProduct!.Product!.Name,
            pickedProduct.QuantityPicked,
            pickedProduct.DatePicked
        );
    }
}
