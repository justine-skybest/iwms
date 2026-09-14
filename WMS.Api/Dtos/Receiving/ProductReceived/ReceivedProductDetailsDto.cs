using System;

namespace WMS.Api.Dtos.Receiving;

public record class ReceivedProductDetailsDto
(
    int Id,
    int ProductId,
    int Quantity,
    string CBM,
    string TotalWeight,
    DateOnly ExpirationDate,
    string Remarks,
    string ContainerName,
    int? PalletId
);

