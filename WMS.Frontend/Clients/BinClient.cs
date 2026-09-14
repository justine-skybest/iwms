using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class BinClient(HttpClient httpClient)
{
    public async Task<BinSummary[]> GetBinsAsync()
        => await httpClient.GetFromJsonAsync<BinSummary[]>("bin") ?? [];
    
    public async Task<BinDetails[]> GetAvailableBinAsync(int WarehouseId) 
        => await httpClient.GetFromJsonAsync<BinDetails[]>($"bin/AvailableBin/{WarehouseId}") ?? [];

    public async Task<BinSummary> GetBinByHashCodeAsync(int HasCode, int WarehouseId)
        => await httpClient.GetFromJsonAsync<BinSummary>($"bin/QRCode/{HasCode}/{WarehouseId}")
         ?? throw new Exception("Could not find the Bin!");

    public async Task<BinSummary> GetCheckedInBinByHashCodeAsync(int HasCode, int WarehouseId)
        => await httpClient.GetFromJsonAsync<BinSummary>($"bin/CheckedIn/{HasCode}/{WarehouseId}")
         ?? throw new Exception("Could not find the Bin!");

    public async Task<BinSummary[]> GetBinsByRackAsync(int id) 
        => await httpClient.GetFromJsonAsync<BinSummary[]>($"bin/rack/{id}") ?? [];

    public async Task<BinSummary[]> GetBinsByBayAsync(int rackId, int bayId) 
        => await httpClient.GetFromJsonAsync<BinSummary[]>($"bin/rack/{rackId}/bay/{bayId}") ?? [];

     public async Task<DisplayCheckInProducts[]> GetBinStockDetailsAsync(int BinId)
        => await httpClient.GetFromJsonAsync<DisplayCheckInProducts[]>($"bin/stock/id/{BinId}") ?? [];

    public async Task<BinMovementHistory[]> GetBinContentMovement(int id)
    => await httpClient.GetFromJsonAsync<BinMovementHistory[]>($"bin/history/{id}") 
       ?? Array.Empty<BinMovementHistory>();

    public async Task AddBinAsync(BinDetails bin)
        => await httpClient.PostAsJsonAsync("bin", bin);

    public async Task<BinDetails> GetBinAsync(int id)
        => await httpClient.GetFromJsonAsync<BinDetails>($"bin/{id}")
        ?? throw new Exception("Could not find the bin!");
        
    public async Task UpdateBinAsync(BinDetails updateBin)
        => await httpClient.PutAsJsonAsync($"bin/{updateBin.Id}", updateBin);

    public async Task DeleteBinAsync(int id)
        => await httpClient.DeleteAsync($"bin/{id}");
}
