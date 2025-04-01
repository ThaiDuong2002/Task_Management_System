﻿using System.Collections.ObjectModel;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.NotificationAggregate;

namespace Backend.Infrastructure.Persistence;

public class NotificationRepository : INotificationRepository
{
    private static readonly List<Notification> _notifications = new();

    public ReadOnlyCollection<Notification> GetAll(Guid userId, int page, int limit)
    {
        var notifications = _notifications
            .Where(n => n.UserId.Value == userId)
            .Skip(page * limit)
            .Take(limit)
            .ToList();

        return notifications.AsReadOnly();
    }

    public void Create(Notification notification)
    {
        _notifications.Add(notification);
    }

    public int Delete(Notification notification)
    {
        var index = _notifications.IndexOf(notification);
        if (index >= 0)
        {
            _notifications.RemoveAt(index);
            return 1;
        }

        return 0;
    }
}