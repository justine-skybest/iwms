using System;
using WMS.Api.Dtos.Receiving;
using WMS.Api.Interfaces;

namespace WMS.Api.Entities;

public class ReceivedProduct : IProductBase
{
    public int ReceivingId { get; set; }
    public Receiving? Receiving { get; set; }

    // --- NEW: Status Tracking ---
    public ReceivedItemStatus Status { get; set; } = ReceivedItemStatus.Matched;

    // --- BASELINE EXPECTED VALUES (From Incoming Packing List) ---
    public int? ExpectedQuantity { get; set; }
    public decimal? ExpectedCBM { get; set; }
    public decimal? ExpectedTotalWeight { get; set; }
    public DateOnly? ExpectedExpirationDate { get; set; }
    public string? ExpectedProductName { get; set; }

    /// <summary>
    /// Computed quantity variance (Actual Received - Expected).
    /// </summary>
    public int Variance => Quantity - (ExpectedQuantity ?? 0);

    public required string ContainerName { get; set; }

    public string? LotNumber { get; set; }
    public string? TypeOfPackage { get; set; }
    public int? PalletId { get; set; }
    public Pallet? Pallet { get; set; }

    // Direct link to the source Incoming line item
    public int? IncomingProductId { get; set; }
    public IncomingProduct? IncomingProduct { get; set; }

    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

    // --- NEW: Exception Record (1-to-0..1 Relationship) ---
    // Only populated if Status is NOT Matched
    public ReceivingException? ExceptionRecord { get; set; }
}