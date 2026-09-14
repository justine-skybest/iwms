using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class WarehouseClient(HttpClient httpClient)
{
    public async Task<WarehouseSummary[]> GetWarehousesAsync()
        => await httpClient.GetFromJsonAsync<WarehouseSummary[]>("warehouse") ?? [];

    public async Task AddWarehouseAsync(WarehouseDetails warehouse) 
        => await httpClient.PostAsJsonAsync("warehouse", warehouse);

    public async Task<WarehouseDetails> GetWarehouseAsync(int id) 
        => await httpClient.GetFromJsonAsync<WarehouseDetails>($"warehouse/{id}")
        ?? throw new Exception("Could not find the warehouse!");

    public async Task UpdateWarehouseAsync(WarehouseDetails updateWarehouse)
        => await httpClient.PutAsJsonAsync($"warehouse/{updateWarehouse.Id}", updateWarehouse);

    public async Task DeleteWarehouseAsync(int id)
        => await httpClient.DeleteAsync($"warehouse/{id}");
}
