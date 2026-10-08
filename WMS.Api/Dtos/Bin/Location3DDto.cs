namespace WMS.Api.Dtos.Bin
{
    public record Location3DDto(
        float PositionX,
        float PositionY,
        float PositionZ,
        float RotationY,
        float Width,
        float Height,
        float Depth
    );
}
