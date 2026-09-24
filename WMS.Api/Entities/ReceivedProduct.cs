using System;
using WMS.Api.Interfaces;

namespace WMS.Api.Entities;

public class ReceivedProduct : IProductBase
{
    public int ReceivingId { get; set; }
    public Receiving? Receiving { get; set; }

    // --- BASELINE EXPECTED VALUES (From Incoming Packing List) ---
    public int? ExpectedQuantity { get; set; }
    public string? ExpectedCBM { get; set; }
    public string? ExpectedTotalWeight { get; set; }
    public DateOnly? ExpectedExpirationDate { get; set; }
    public string? ExpectedProductName { get; set; }

    /// <summary>
    /// Computed quantity variance (Actual Received - Expected).
    /// </summary>
    public int Variance => Quantity - (ExpectedQuantity ?? 0);

    public required string ContainerName { get; set; }
    public int? PalletId { get; set; }
    public Pallet? Pallet { get; set; }

    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
}