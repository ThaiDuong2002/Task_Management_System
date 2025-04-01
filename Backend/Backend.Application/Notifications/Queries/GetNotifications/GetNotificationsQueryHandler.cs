using System.Collections.ObjectModel;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.NotificationAggregate;
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

    public async Task<ErrorOr<ReadOnlyCollection<Notification>>> Handle(GetNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var notifications = _notificationRepository.GetAll(Guid.Parse(request.UserId), request.Page, request.Limit);

        return notifications;
    }
}