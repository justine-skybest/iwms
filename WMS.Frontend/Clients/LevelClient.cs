using System;
using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class LevelClient(HttpClient httpClient)
{
        public async Task<LevelSummary[]> GetLevelAsync()
           => await httpClient.GetFromJsonAsync<LevelSummary[]>("level") ?? [];

        public async Task<LevelSummary[]> GetLevelAsync(int id)
            => await httpClient.GetFromJsonAsync<LevelSummary[]>($"level/LessOrEqual/{id}") ?? [];
}
