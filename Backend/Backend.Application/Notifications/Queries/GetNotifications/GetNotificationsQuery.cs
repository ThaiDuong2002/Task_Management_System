using System.Collections.ObjectModel;
using Backend.Domain.NotificationAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Notifications.Queries.GetNotifications;

public record GetNotificationsQuery(
    string UserId,
    int Page,
    int Limit
) : IRequest<ErrorOr<ReadOnlyCollection<Notification>>>;