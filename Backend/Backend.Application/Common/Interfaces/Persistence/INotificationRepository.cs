using System.Collections.ObjectModel;
using Backend.Domain.NotificationAggregate;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface INotificationRepository
{
    void Create(Notification notification);
    int Delete(Notification notification);
    ReadOnlyCollection<Notification> GetAll(Guid userId, int page, int limit);
}