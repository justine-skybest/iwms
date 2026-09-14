using System;

namespace WMS.Api.Dtos.Product;

public record class ProductDetailsDto(
    int Id,
    string Name,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,
    DateTime DateAdded
);
