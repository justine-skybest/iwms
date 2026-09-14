using System;

namespace WMS.Frontend.Models;



public class ProductMovementModel
{
    public string ReceivingSeries { get; set; } = "";
    public int ReceivedProductId { get; set; }
    public string Name { get; set; } = "";
    public int QuantityPicked { get; set; }
    public int QuantityLeft { get; set; }
    public string? Remarks { get; set; }
    public string Shipper { get; set; } = "";
}