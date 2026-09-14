using System;

namespace WMS.Api.Dtos.Bin;

public record ProductMovementDto(
    string ReceivingSeries,
    int ReceivedProductId,
    string Name,
    int QuantityPicked,
    int QuantityLeft,
    string? Remarks,
    string Shipper
);