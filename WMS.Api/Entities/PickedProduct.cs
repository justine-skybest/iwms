using System;

namespace WMS.Api.Entities;

public class PickedProduct
{
    public int Id { get; set; }

    public int ManualPickingId { get; set; }  

    public ManualPicking? ManualPicking { get; set; } 

    public int ReceivedProductId { get; set; }

    public ReceivedProduct? ReceivedProduct { get; set; } 

    public int QuantityPicked { get; set; } 
    
    public DateTime DatePicked { get; set; }
}
