using Backend.Domain.Common.Models;
using Backend.Domain.NotificationAggregate.ValueObjects;
using Backend.Domain.TaskAggregate.ValueObjects;
using Backend.Domain.User.ValueObjects;

namespace Backend.Domain.NotificationAggregate;

public class Notification : Entity<NotificationId>
{
    private Notification(UserId userId, TaskId taskId, NotificationType type, string message,
        DateTime createdAt) : base(
        NotificationId.CreateUnique())
    {
        UserId = userId;
        TaskId = taskId;
        Type = type;
        Message = message;
        CreatedAt = createdAt;
    }

    public UserId UserId { get; }
    public TaskId TaskId { get; }
    public NotificationType Type { get; }
    public string Message { get; }
    public DateTime CreatedAt { get; }

    public static Notification Create(UserId userId, TaskId taskId, NotificationType type, string message,
        DateTime createdAt)
    {
        return new Notification(userId, taskId, type, message, createdAt);
    }
}