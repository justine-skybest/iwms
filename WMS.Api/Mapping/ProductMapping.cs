using System;
using WMS.Api.Dtos.Product;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class ProductMapping
{
    public static Product ToEntity(this CreateProductDto product)
    {
        return new Product()
        {
            Name = product.Name,
            Code = product.Code,
            TypeOfPackage = product.TypeOfPackage,
            Measurement = product.Measurement,
            Weight = product.Weight,
            DateAdded = product.DateAdded
        };
    }

    public static Product ToEntity(this UpdateProductDto product, int id)
    {
        return new Product()
        {
            Id = id,
            Name = product.Name,
            Code = product.Code,
            TypeOfPackage = product.TypeOfPackage,
            Measurement = product.Measurement,
            Weight = product.Weight,
            DateAdded = product.DateAdded
        };
    }

    public static ProductDetailsDto ToProductDetailsDto(this Product product)
    {
        return new (
            product.Id,
            product.Name,
            product.TypeOfPackage,
            product.Measurement,
            product.Weight,
            product.DateAdded
        );
    }

    public static ProductSummaryDto ToProductSummaryDto(this Product product)
    {
        return new (
            product.Id,
            product.Name,
            product.TypeOfPackage,
            product.Measurement,
            product.Weight,
            product.DateAdded
        );
    }
}
