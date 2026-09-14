namespace WMS.Api.Entities;

public class Warehouse
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Address {get; set;}

    public byte[]? FloorPlanImage {get; set;}

    public DateTime DateAdded { get; set; }

    public ICollection<Receiving>? Receivings { get; set; }

    public ICollection<Pallet>? Pallets { get; set; }
}
