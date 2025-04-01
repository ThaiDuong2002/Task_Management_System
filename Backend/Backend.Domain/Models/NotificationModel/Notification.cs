using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.NotificationModel.ValueObjects;
using Backend.Domain.Models.UserModel.ValueObjects;

namespace Backend.Domain.Models.NotificationModel;

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