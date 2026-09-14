namespace WMS.Api.Entities;

public class Bin
{
    public int Id { get; set; }  

    public int RackId { get; set; }

    public Rack? Rack { get; set; }

    public int BayId {get; set;}

    public Bay? Bay {get; set;}

    public int LevelId {get; set;}

    public Level? Level { get; set; }

    public int BinNamesId {get; set;}

    public BinNames? BinNames {get; set;}

    public int BinHashCode { get; set; }

    public DateTime DateAdded { get; set; }

    public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
}
