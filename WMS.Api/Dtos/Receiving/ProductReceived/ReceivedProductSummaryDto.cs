namespace WMS.Api.Dtos.Receiving;

public record class ReceivedProductSummaryDto(
    int id,
    string Name,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,
    decimal Quantity,
    string CBM,
    string TotalWeight,
    DateOnly ExpirationDate,
    string Remarks,
    string ContainerName,
    string? PalletId
);