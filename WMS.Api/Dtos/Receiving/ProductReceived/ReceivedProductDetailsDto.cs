using System;

namespace WMS.Api.Dtos.Receiving;

public record class ReceivedProductDetailsDto
{
    public int Id { get; set; }
    public int ProductId { get; init; }

    // --- Expected Baseline Fields ---
    public string? ExpectedProductName { get; init; }
    public int? ExpectedQuantity { get; init; }
    public string? ExpectedCBM { get; init; }
    public string? ExpectedTotalWeight { get; init; }
    public DateOnly? ExpectedExpirationDate { get; init; }

    // --- Actual Counted / Received Fields ---
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public string CBM { get; init; } = "0";
    public string TotalWeight { get; init; } = "0";
    public DateOnly? ExpirationDate { get; init; }

    public string? Supplier { get; init; }
    public string? Remarks { get; init; }
    public string? ContainerName { get; init; }
    public int? PalletId { get; init; }
}

