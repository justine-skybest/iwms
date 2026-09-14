using System;

namespace WMS.Frontend.Models;

public class CheckInSummary
{
    public int Id {get;set;}
    public required string CheckInType {get; set;}
    public required List<BinSummary> Bins {get;set;}
    public required string PalletNumber {get;set;}
    public required List<ReceivedProductSummary> ReceivedProducts {get;set;}
    public DateTime CheckInDate {get;set;}
    public string? Notes {get;set;}
}
