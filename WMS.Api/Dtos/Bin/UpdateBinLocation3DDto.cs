namespace WMS.Api.Dtos.Bin
{
    public record UpdateBinLocation3DDto(
        float PositionX,
        float PositionY,
        float PositionZ,
        float RotationY
    );
}
