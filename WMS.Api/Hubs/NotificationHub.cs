using Microsoft.AspNetCore.SignalR;

namespace WMS.Api.Hubs;

public class NotificationHub : Hub<INotificationClient>
{
}