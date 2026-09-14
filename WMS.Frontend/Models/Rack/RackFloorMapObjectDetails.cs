using System;
using System.ComponentModel.DataAnnotations;

namespace WMS.Frontend.Models;

public class RackFloorMapObjectDetails
{
     public int Id { get; set; }
    
    public int RackId { get; set; }

    public string? Type { get; set; }
    
    public float Left { get; set; }
    
    public float Top { get; set; }
    
    public float Width { get; set; }
    
    public float Height { get; set; }
    
    public string? Text { get; set; } 
    
    public string? Fill { get; set; }
    
    public string? Stroke { get; set; }

    public double StrokeWidth { get; set; }
    
    public int FontSize { get; set; } 

    public float ScaleX { get; set; } 

    public float ScaleY { get; set; } 

    public float Angle { get; set; } 
}
