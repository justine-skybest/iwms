using WMS.Api.Dtos.Receiving;

namespace WMS.Api.Entities;

public class Receiving
{
    public int Id { get; set; }

    public required string Series {get;set;}

    public int WarehouseId {get; set;}

    public Warehouse? Warehouse {get;set;}

    public required string TransportCompany { get; set; }
    
    public required string Shipper { get; set; }

    public  string? Consignee {get;set;}

    public DateTime DateReceived { get; set; }

    public required string Reference {get;set;}

    public required List<ReceivedProduct> Products { get; set; }    

    public required string PlateNumber {get;set;}

    public required string  DriverName { get; set; }

    public DateTime DateTime {get;set;}

    public string? ClientRepresentative { get; set; }

    public string? CheckerName { get; set; }

    public DateTime TimeStart {get;set;}

    public DateTime TimeEnd {get;set;}

    public DateTime DateAdded {get;set;}
}
