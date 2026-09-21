namespace WMS.Api.Hubs
{
    public interface INotificationClient
    {
        Task ReceivingCreated();
        Task ReceivingUpdated();
        Task CheckinCreated();
        Task CheckinUpdated();
        Task ReceivingDeleted();
        Task InventoryUpdated();
        Task PalletCreated();
        Task PalletUpdated();
        Task ProductCreated();
        Task ProductUpdated();
        Task WarehouseCreated();
        Task WarehouseUpdated();
    }
}
