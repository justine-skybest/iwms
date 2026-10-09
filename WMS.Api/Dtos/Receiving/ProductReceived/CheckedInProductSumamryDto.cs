using System;

namespace WMS.Api.Dtos.Receiving;

public record class CheckedInProductSumamryDto(
    int id,
    string Name,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,
    decimal Quantity,
    decimal CBM,
    decimal? TotalWeight,
    DateOnly? ExpirationDate,
    string Remarks,
    string ContainerName,
    string? PalletId,
    string ReceivingSeries,
    string Shipper
);