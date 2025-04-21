namespace Backend.Application.Common.Interfaces.Services;

public interface INotificationHub
{
    Task SendNotification(string message);
}