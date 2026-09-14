using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class CheckInClient(HttpClient httpClient)
{
    public async Task<CheckInSummary[]> GetCheckInsAsync()
        => await httpClient.GetFromJsonAsync<CheckInSummary[]>("checkin") ?? [];

    public async Task<DisplayCheckInProducts[]> GetCheckInByBinAsync(int id)
        => await httpClient.GetFromJsonAsync<DisplayCheckInProducts[]>($"checkin/Bin/{id}") ?? [];


    public async Task<CheckInDetails> GetCheckInsAsync(int id)
        => await httpClient.GetFromJsonAsync<CheckInDetails>($"checkin/{id}")
        ?? throw new Exception("Could not find the checkin!");

    public async Task AddCheckInAsync(CheckInDetails checkin)
        => await httpClient.PostAsJsonAsync("checkin", checkin);
}
