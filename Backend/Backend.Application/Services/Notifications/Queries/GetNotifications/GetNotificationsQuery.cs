using Backend.Domain.Models.NotificationModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Notifications.Queries.GetNotifications;

public record GetNotificationsQuery(
    Guid UserId,
    int? Page,
    int? Limit
) : IRequest<ErrorOr<List<Notification>>>;