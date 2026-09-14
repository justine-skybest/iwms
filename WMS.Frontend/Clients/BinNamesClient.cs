using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class BinNamesClient(HttpClient httpClient)
{
    public async Task<BinNameSummary[]> GetBinNamesAsync () 
        => await httpClient.GetFromJsonAsync<BinNameSummary[]>("binnames") ?? [];

    public async Task<BinNameSummary> GetBinNamesAsync (int id) 
        => await httpClient.GetFromJsonAsync<BinNameSummary>($"binnames/{id}") 
        ?? throw new Exception("Could not find the Bin Name!");

    public async Task<BinNameSummary[]> GetBinNamesAsync(int rackId, int bayId, int levelId)
        => await httpClient.GetFromJsonAsync<BinNameSummary[]>($"binnames/rack/{rackId}/bay/{bayId}/level/{levelId}/")
        ?? [];

     public async Task<BinNameSummary[]> GetBinNamesAsync(int rackId, int bayId, int levelId, int binNameId)
        => await httpClient.GetFromJsonAsync<BinNameSummary[]>($"binnames/rack/{rackId}/bay/{bayId}/level/{levelId}/binName/{binNameId}")
        ?? [];
}
