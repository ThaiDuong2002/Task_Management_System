using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.AssignmentAggregate.ValueObjects;
using Backend.Domain.NotificationAggregate;
using Backend.Domain.NotificationAggregate.ValueObjects;
using Backend.Domain.User.ValueObjects;
using ErrorOr;
using MediatR;

namespace Backend.Application.Notifications.Commands.CreateNotification;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, ErrorOr<Notification>>
{
    private readonly INotificationRepository _notificationRepository;

    public CreateNotificationCommandHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<ErrorOr<Notification>> Handle(CreateNotificationCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var notification = Notification.Create(
            UserId.Create(Guid.Parse(command.UserId)),
            AssignmentId.Create(Guid.Parse(command.AssignmentId)),
            NotificationType.Create(command.Type),
            command.Message,
            DateTime.UtcNow
        );

        _notificationRepository.Create(notification);

        return notification;
    }
}