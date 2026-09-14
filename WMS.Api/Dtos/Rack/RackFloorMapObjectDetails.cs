using System;

namespace WMS.Api.Dtos;

public record class RackFloorMapObjectDetails
(
    int Id,
    int RackId,
    string Type,
    float Left,  
    float Top,    
    float Width,    
    float Height,    
    string? Text,     
    string? Fill,    
    string? Stroke,
    double StrokeWidth,    
    int FontSize,
    float ScaleX,
    float ScaleY,
    float Angle
);

