using WMS.Api.Dtos.Receiving;
using WMS.Api.Interfaces;

namespace WMS.Api.Entities;

public class Receiving : IIncomingShipment<ReceivedProduct>
{
    public int? IncomingId { get; set; }
    public Incoming? Incoming { get; set; }
    public required string Series { get; set; }
    public required string TransportCompany { get; set; }
    public required string Reference { get; set; }
    public required string PlateNumber { get; set; }
    public required string DriverName { get; set; }

    public string? ClientRepresentative { get; set; }
    public string? CheckerName { get; set; }

    public DateTime DateReceived { get; set; }
    public DateTime DateTime { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime TimeEnd { get; set; }
    public DateTime DateAdded { get; set; }
}
