using System.ComponentModel.DataAnnotations;

namespace WMS.Frontend.Models;

public class PickedProductSummary
{
    public required string ReceivedProductId { get; set; }

    public required string ProductName { get; set; }

    public required string Source { get; set; }

    public int CurrentQuantity { get; set; }
    
    public int QuantityPicked { get; set; }

    public DateTime DatePicked {get;set;}
}
