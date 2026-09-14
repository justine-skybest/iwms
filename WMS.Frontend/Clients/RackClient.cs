using System;
using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class RackClient(HttpClient httpClient)
{
    public async Task<RackSummary[]> GetRacksAsync() 
        => await httpClient.GetFromJsonAsync<RackSummary[]>("rack") ?? [];

    public async Task<RackSummary[]> GetRacksAsync(int id) 
        => await httpClient.GetFromJsonAsync<RackSummary[]>($"rack/warehouse/{id}") ?? [];

    public async Task AddRackAsync(RackDetails rack)
        => await httpClient.PostAsJsonAsync("rack", rack);
    
    public async Task<RackDetails> GetRackAsync(int id)
        => await httpClient.GetFromJsonAsync<RackDetails>($"rack/{id}")
        ?? throw new Exception("Could not find the rack!");

    public async Task<RackDetails> GetRackByBinAsync(int id) =>
        await httpClient.GetAsync($"rack/bin/{id}") is { IsSuccessStatusCode: true } response &&
        await response.Content.ReadFromJsonAsync<RackDetails>() is RackDetails rack
            ? rack
            : throw new Exception($"Could not find or deserialize rack for bin {id}!");

    public async Task UpdateRackAsync(RackDetails updateRack)
        => await httpClient.PutAsJsonAsync($"rack/{updateRack.Id}", updateRack);

    public async Task DeleteRackAsync(int id)
        => await httpClient.DeleteAsync($"rack/{id}");
}
