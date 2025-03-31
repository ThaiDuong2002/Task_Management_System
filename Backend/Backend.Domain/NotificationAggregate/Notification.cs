using Backend.Domain.AssignmentAggregate.ValueObjects;
using Backend.Domain.Common.Models;
using Backend.Domain.NotificationAggregate.ValueObjects;
using Backend.Domain.User.ValueObjects;

namespace Backend.Domain.NotificationAggregate;

public class Notification : Entity<NotificationId>
{
    private Notification(UserId userId, AssignmentId assignmentId, NotificationType type, string message,
        DateTime createdAt) : base(
        NotificationId.CreateUnique())
    {
        UserId = userId;
        AssignmentId = assignmentId;
        Type = type;
        Message = message;
        CreatedAt = createdAt;
    }

    public UserId UserId { get; }
    public AssignmentId AssignmentId { get; }
    public NotificationType Type { get; }
    public string Message { get; }
    public DateTime CreatedAt { get; }

    public static Notification Create(UserId userId, AssignmentId assignmentId, NotificationType type, string message,
        DateTime createdAt)
    {
        return new Notification(userId, assignmentId, type, message, createdAt);
    }
}