using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.NotificationModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Notifications.Queries.GetNotifications;

public class
    GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, ErrorOr<List<Notification>>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationsQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<ErrorOr<List<Notification>>> Handle(GetNotificationsQuery query,
        CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.GetAll(query.UserId, query.Page, query.Limit);

        return notifications;
    }
}