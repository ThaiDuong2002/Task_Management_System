using Backend.Domain.Models.NotificationModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Notifications.Commands.CreateNotification;

public record CreateNotificationCommand(
    string UserId,
    string AssignmentId,
    string Message,
    string Type
) : IRequest<ErrorOr<Notification>>;