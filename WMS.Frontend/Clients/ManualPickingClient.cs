using WMS.Frontend.Models;

namespace WMS.Frontend.Clients;

public class ManualPickingClient(HttpClient httpClient)
{
    public async Task AddManualPickingAsync(CreateManualPicking picking)
        => await httpClient.PostAsJsonAsync("manualpicking", picking);
}

