using Backend.Domain.Models.NotificationModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface INotificationRepository
{
    Task<int> Create(Notification notification);
    Task<int> Delete(Notification notification);
    Task<List<Notification>> GetAll(Guid userId, int? page, int? limit);
    Task<int> UpdateReadStatus(Guid notificationId);
    Task<int> ReadAll(Guid userId);
    Task<int> CreateUpcomingNotifications();
    Task<int> CreateOverdueNotifications();
}