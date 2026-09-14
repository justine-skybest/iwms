using System.ComponentModel.DataAnnotations;

namespace WMS.Frontend.Models;

public class CheckInDetails
{
    public int Id {get;set;}

    public required string CheckInType {get;set;}

    [Required]
    [Length(1,100,ErrorMessage = "Atleast one bin location is required for Checkin.")]    
    public required List<int> BinIds {get;set;}

    public int? PalletId {get;set;}

    public List<int>? ReceivedProductIds {get;set;}

    public DateTime CheckInDate {get;set;}

    public string? Notes {get;set;}    
}
