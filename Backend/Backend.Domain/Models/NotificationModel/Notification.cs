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

    public Notification() : base(null!)
    {
        UserId = null!;
        AssignmentId = null!;
        Type = NotificationType.Default;
        Message = null!;
        CreatedAt = default!;
    }

    public UserId UserId { get; private set; }
    public AssignmentId AssignmentId { get; private set; }
    public NotificationType Type { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Notification Create(UserId userId, AssignmentId assignmentId, NotificationType type, string message,
        DateTime createdAt)
    {
        return new Notification(userId, assignmentId, type, message, createdAt);
    }
}