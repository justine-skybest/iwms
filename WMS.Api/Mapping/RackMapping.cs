using WMS.Api.Dtos;
using WMS.Api.Entities;

namespace WMS.Api.Mapping;

public static class RackMapping
{
    public static Rack ToEntity(this CreateRackDto rack)
    {
        return new()
        {
            Name = rack.Name,
            WarehouseId = rack.WarehouseId,
            BayId = rack.BayId,
            LevelId = rack.LevelId,
            RackFloorMapObject = rack.RackFloorMapObject?.Select(objects => objects.ToEntity()).ToList() ?? new List<RackFloorMapObject>(),
            IsFloorDocking = rack.IsFloorDocking,
            DateAdded = rack.DateAdded
        };
    }

    public static Rack ToEntity(this UpdateRackDto rack, int id)
    {
        return new(){
            Id = id,
            Name = rack.Name,
            WarehouseId = rack.WarehouseId,
            BayId = rack.BayId,
            LevelId = rack.LevelId,
            RackFloorMapObject = rack.RackFloorMapObject?.Select(objects => objects.ToEntity()).ToList() ?? new List<RackFloorMapObject>(),
            IsFloorDocking = rack.IsFloorDocking,
            DateAdded = rack.DateAdded
        };
}

    public static RackFloorMapObject ToEntity(this RackFloorMapObjectDetails rackFloorMapObjectDetails)
    {
        return new(){
            Id = rackFloorMapObjectDetails.Id,
            RackId = rackFloorMapObjectDetails.RackId,
            Type = rackFloorMapObjectDetails.Type,
            Left = rackFloorMapObjectDetails.Left,
            Top = rackFloorMapObjectDetails.Top,
            Width = rackFloorMapObjectDetails.Width,
            Height = rackFloorMapObjectDetails.Height,
            Text = rackFloorMapObjectDetails.Text,
            Fill = rackFloorMapObjectDetails.Fill,
            Stroke = rackFloorMapObjectDetails.Stroke,
            StrokeWidth = rackFloorMapObjectDetails.StrokeWidth,
            FontSize = rackFloorMapObjectDetails.FontSize,
            ScaleX = rackFloorMapObjectDetails.ScaleX,
            ScaleY = rackFloorMapObjectDetails.ScaleY,
            Angle = rackFloorMapObjectDetails.Angle
        };
    }

    public static RackDetailsDto ToRackDetailsDto (this Rack rack)
    {
        return new
        (
            rack.Id,
            rack.Name,
            rack.WarehouseId,
            rack.BayId,
            rack.LevelId,
            rack.RackFloorMapObject?.Select(objects => objects.ToDetailsDto()).ToList() ?? new List<RackFloorMapObjectDetails>(),
            rack.IsFloorDocking,
            rack.DateAdded
        );
    }

    public static RackFloorMapObjectDetails ToDetailsDto (this RackFloorMapObject rack)
    {
        return new
        (
            rack.Id,
            rack.RackId,
            rack.Type ?? "",
            rack.Left,
            rack.Top,
            rack.Width,
            rack.Height,
            rack.Text,
            rack.Fill,
            rack.Stroke,
            rack.StrokeWidth,
            rack.FontSize,
            rack.ScaleX,
            rack.ScaleY,
            rack.Angle
        );
    }

    public static RackSummaryDto ToRackSummaryDto (this Rack rack)
    {
        return new
        (
            rack.Id,
            rack.Name,
            rack.Warehouse!.Name,
            rack.Bay!.BayNumber.ToString(),
            rack.Level!.LevelNumber.ToString(),
            rack.RackFloorMapObject?.Select(objects => objects.ToDetailsDto()).ToList() ?? new List<RackFloorMapObjectDetails>(),            
            rack.DateAdded
        );
    }
}
