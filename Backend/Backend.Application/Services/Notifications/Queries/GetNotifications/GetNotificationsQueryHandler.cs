using System.Collections.ObjectModel;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.NotificationModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Notifications.Queries.GetNotifications;

public class
    GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, ErrorOr<ReadOnlyCollection<Notification>>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationsQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<ErrorOr<ReadOnlyCollection<Notification>>> Handle(GetNotificationsQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var notifications = _notificationRepository.GetAll(Guid.Parse(query.UserId), query.Page, query.Limit);

        return notifications;
    }
}