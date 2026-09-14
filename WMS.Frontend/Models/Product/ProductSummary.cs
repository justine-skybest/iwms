using System;

namespace WMS.Frontend.Models;

public class ProductSummary
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string TypeOfPackage {get; set;}

    public required string Measurement {get; set;}

    public decimal Weight {get;set;}

    public DateTime DateAdded {get; set;}
}
