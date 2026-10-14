using System;

namespace WMS.Api.Dtos.Product;

public record class ProductSummaryDto(
    int Id,
    string Code,
    string Name,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,
    DateTime DateAdded
);