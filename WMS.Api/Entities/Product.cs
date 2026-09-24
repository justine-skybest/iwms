using Microsoft.EntityFrameworkCore;

namespace WMS.Api.Entities;

public class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }
    public required string Name { get; set; }
    
    public required string TypeOfPackage { get; set; }

    public required string Measurement {get;set;}

    [Precision(18, 2)]
    public required decimal Weight {get;set;}  

    public DateTime DateAdded { get; set; }
}
