namespace WMS.Api.Entities;

public class CheckIn
{
    public int Id { get; set; }

    public required string CheckInType { get; set; }

    public List<Bin> Bins { get; set; } = new();

    public int? PalletId { get; set; }

    public Pallet? Pallet { get; set; }

    public List<ReceivedProduct> ReceivedProducts { get; set; } = new();

    public DateTime CheckInDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }
}
