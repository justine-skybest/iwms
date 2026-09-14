using System;
using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class PalletClient(HttpClient httpClient)
{
    public async Task<PalletSummary[]> GetPalletsAsync() 
        => await httpClient.GetFromJsonAsync<PalletSummary[]>("pallet") ?? [];

    public async Task<PalletSummary[]> GetPalletsByWarehouseAsync(int id) 
        => await httpClient.GetFromJsonAsync<PalletSummary[]>($"pallet/Warehouse/{id}") ?? [];

    public async Task<PalletDetails> GetPalletAsync(int id)
        => await httpClient.GetFromJsonAsync<PalletDetails>($"pallet/{id}")
        ?? throw new Exception("Could not find the pallet!");
    
    public async Task<PalletToBeCheckIn[]> GetPalletToCheckIn(int WarehouseId) 
        => await httpClient.GetFromJsonAsync<PalletToBeCheckIn[]>($"pallet/ToBeCheckIn/{WarehouseId}") ?? [];

    public async Task<PalletDetails> GetPalletByHashCodeAsync(int PalletHasCode, int WarehouseId)
        => await httpClient.GetFromJsonAsync<PalletDetails>($"pallet/QRCode/{PalletHasCode}/{WarehouseId}")
        ?? throw new Exception("Could not find the pallet!");

    public async Task<int> GetPalletNumberAsync(int WarehouseId)
        => await httpClient.GetFromJsonAsync<int>($"pallet/number/{WarehouseId}");

    public async Task AddPalletAsync(PalletDetails pallet)
        => await httpClient.PostAsJsonAsync("pallet", pallet);

    public async Task<PalletDetails> AutomaticAddPalletAsync(int WarehouseId)
    {
        var response = await httpClient.PostAsync($"pallet/autocreate/{WarehouseId}", null);
        // Check if the response is successful
        if (response.IsSuccessStatusCode)
        {
            // Deserialize the JSON response into a PalletSummary object
            return await response.Content.ReadFromJsonAsync<PalletDetails>() ?? new PalletDetails();
        }
        
        return new PalletDetails();
    }

    public async Task UpdatePalletAsync(PalletDetails updatedPallet)
        => await httpClient.PutAsJsonAsync($"pallet/{updatedPallet.Id}", updatedPallet);

    public async Task DeletePalletAsync(int id)
        => await httpClient.DeleteAsync($"pallet/{id}");
}
