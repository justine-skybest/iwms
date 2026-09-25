namespace WMS.Api.Dtos.Receiving;

public record class ReceivedProductSummaryDto(
    int Id,
    int ProductId,
    string Name,
    string LotNumber,
    string TypeOfPackage,
    string Measurement,
    decimal Weight,

    // --- Baseline Expected Fields ---
    string? ExpectedProductName,
    int? ExpectedQuantity,
    string? ExpectedCBM,
    string? ExpectedTotalWeight,
    DateOnly? ExpectedExpirationDate,

    // --- Actual Counted / Received Fields ---
    int Quantity,
    string CBM,
    string TotalWeight,
    DateOnly? ExpirationDate,
    string Remarks,
    string ContainerName,
    int? PalletId
)
{
    /// <summary>
    /// Quantity Variance (Actual Received - Baseline Expected)
    /// </summary>
    public int Variance => Quantity - (ExpectedQuantity ?? 0);

    /// <summary>
    /// True if any baseline expectation differs from the actual received entry.
    /// </summary>
    public bool HasDiscrepancy =>
        Variance != 0 ||
        (ExpectedCBM != null && CBM != ExpectedCBM) ||
        (ExpectedTotalWeight != null && TotalWeight != ExpectedTotalWeight) ||
        (ExpectedExpirationDate != null && ExpirationDate != ExpectedExpirationDate) ||
        (ExpectedProductName != null && !string.Equals(Name, ExpectedProductName, StringComparison.OrdinalIgnoreCase));
}