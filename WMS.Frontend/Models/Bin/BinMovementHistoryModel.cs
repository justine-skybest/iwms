using System;

namespace WMS.Frontend.Models;

public class BinMovementHistory
{
    public string MovementType { get; set; } = "";
    public int MovementId { get; set; }
    public DateTime Date { get; set; }
    public string? PalletNumber { get; set; }
    public List<ProductMovementModel> Products { get; set; } = new();
    public string? Notes { get; set; }
}