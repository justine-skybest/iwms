using System;

namespace WMS.Api.Dtos.Receiving;

public record class ReceivedProductDetailsDto
{
    public int Id { get; set; }
    public int ProductId { get; init; }

    // ✅ Add explicit link to the source IncomingProduct line item
    public int? IncomingProductId { get; set; }

    // --- Expected Baseline Fields ---
    public string? ExpectedProductName { get; init; }
    public int? ExpectedQuantity { get; init; }
    public decimal? ExpectedCBM { get; init; }
    public decimal? ExpectedTotalWeight { get; init; }
    public DateOnly? ExpectedExpirationDate { get; init; }

    // --- Actual Counted / Received Fields ---
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public decimal CBM { get; init; } = 0m;
    public decimal Weight { get; init; }
    public decimal TotalWeight => Math.Round(Weight * Quantity, 2, MidpointRounding.AwayFromZero);
    public decimal TotalAmount { get; set; }
    public decimal UnitPrice { get; set; }
    public DateOnly? ExpirationDate { get; init; }

    public string? Supplier { get; init; }
    public string? Remarks { get; init; }
    public string? ContainerName { get; init; }
    public string? LotNumber { get; set; }
    public string? TypeOfPackage { get; set; }
    public int? PalletId { get; init; }
}
