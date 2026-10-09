using System;

namespace WMS.Api.Dtos.Receiving;

public record class ToCheckInProducts(
    int Id,
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
    int ReceivingId,
    string ReceivingSeries
);
