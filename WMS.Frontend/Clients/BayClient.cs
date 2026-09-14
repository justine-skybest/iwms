using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class BayClient(HttpClient httpClient)
{
    public async Task<BaySummary[]> GetBayAsync() 
        =>  await httpClient.GetFromJsonAsync<BaySummary[]>("bay") ?? [];
    public async Task<BaySummary[]> GetBayAsync(int id) 
        =>  await httpClient.GetFromJsonAsync<BaySummary[]>($"bay/lessOrEqual/{id}") ?? [];
}
