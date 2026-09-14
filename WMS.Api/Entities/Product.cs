namespace WMS.Api.Entities;

public class Product
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public required string TypeOfPackage { get; set; }

    public required string Measurement {get;set;}

    public required decimal Weight {get;set;}  

    public DateTime DateAdded { get; set; }
}
