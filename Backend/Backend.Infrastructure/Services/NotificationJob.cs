using Backend.Application.Common.Interfaces.Persistence;
using Backend.Infrastructure.Persistence;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace Backend.Infrastructure.Services;

public class NotificationJob : IJob
{
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly INotificationRepository _notificationRepository;

    public NotificationJob(IHubContext<NotificationHub> notificationHub, INotificationRepository notificationRepository,
        PostgresDbContext dbContext)
    {
        _notificationHub = notificationHub;
        _notificationRepository = notificationRepository;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await _notificationRepository.CreateOverdueNotifications();
        await _notificationRepository.CreateUpcomingNotifications();
        await _notificationHub.Clients.All.SendAsync("ReceiveNotification", "Test notification");
    }
}