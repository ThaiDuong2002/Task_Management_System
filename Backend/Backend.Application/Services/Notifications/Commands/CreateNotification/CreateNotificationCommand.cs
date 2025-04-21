using Backend.Domain.Models.NotificationModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Notifications.Commands.CreateNotification;

public record CreateNotificationCommand(
    Guid UserId,
    string AssignmentId,
    string Message,
    string Type,
    DateTime ScheduledTime
) : IRequest<ErrorOr<Notification>>;