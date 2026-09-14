namespace WMS.Frontend.Models;

public class DisplayCheckInProducts
{
    public int Id { get; set; }
    public required string CheckInType { get; set; }
    public required string PalletNumber {get;set;}
    public required List<CheckedInProductSummary> ReceivedProducts {get;set;}
    public DateTime CheckInDate {get;set;}
    public string? Notes {get;set;}
}
