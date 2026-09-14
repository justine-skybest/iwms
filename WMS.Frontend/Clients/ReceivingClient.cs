using WMS.Frontend.Models;
namespace WMS.Frontend.Clients;

public class ReceivingClient(HttpClient httpClient)
{
    public async Task<ReceivingSummary[]> GetReceivingsAsync()
        => await httpClient.GetFromJsonAsync<ReceivingSummary[]>("receiving") ?? [];

    public async Task<ReceivingSummary[]> GetReceivingsByWarehouseAsync(int WarehouseId)
        => await httpClient.GetFromJsonAsync<ReceivingSummary[]>($"receiving/warehouse/{WarehouseId}") ?? [];
    
    public async Task<string> GetReceivingSeriesAsync()
        => await httpClient.GetFromJsonAsync<string>("receiving/series") ?? "";

    public async Task AddReceivingAsync (ReceivingDetails receiving) 
        => await httpClient.PostAsJsonAsync("receiving", receiving);

    public async Task<ReceivingDetails> GetReceivingAsync(int id)
        => await httpClient.GetFromJsonAsync<ReceivingDetails>($"receiving/{id}")
        ?? throw new Exception("Could not find the Receiving Tally.");

    public async Task UpdateReceivingAsync(ReceivingDetails updatedReceiving)        
        => await httpClient.PutAsJsonAsync($"receiving/{updatedReceiving.Id}", updatedReceiving);

    public async Task DeleteReceivingAsync(int id)
        => await httpClient.DeleteAsync($"receiving/{id}");

    public async Task<ToCheckInProductSummary[]> GetToCheckInProduct(int WarehouseId)
        => await httpClient.GetFromJsonAsync<ToCheckInProductSummary[]>($"receivedProduct/ToCheckInProducts/{WarehouseId}") ?? [];
}
