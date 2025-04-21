using Backend.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Infrastructure.Services;

public class NotificationHub : Hub, INotificationHub
{
    public async Task SendNotification(string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}