namespace WMS.Api.Dtos.Transfer
{
    public record TransferBinDto(
        int FromBinId,
        int ToBinId,
        string? Notes
    );
}
