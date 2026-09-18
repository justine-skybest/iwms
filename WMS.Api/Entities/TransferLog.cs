namespace WMS.Api.Entities;

public class TransferLog
{
    public int Id { get; set; }

    public required string TransferType { get; set; }

    public int WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public int? PalletId { get; set; }

    public Pallet? Pallet { get; set; }

    public int? ReceivedProductId { get; set; }

    public ReceivedProduct? ReceivedProduct { get; set; }

    public int FromBinId { get; set; }

    public Bin? FromBin { get; set; }

    public int ToBinId { get; set; }

    public Bin? ToBin { get; set; }

    public DateTime TransferDate { get; set; }

    public string? Notes { get; set; }
}
