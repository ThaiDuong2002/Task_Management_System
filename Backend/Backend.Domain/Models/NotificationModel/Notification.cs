using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.NotificationModel.ValueObjects;

namespace Backend.Domain.Models.NotificationModel;

public class Notification : Entity<NotificationId>
{
    private Notification(Guid userId, AssignmentId assignmentId, NotificationType type, string message,
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
        UserId = Guid.Empty;
        AssignmentId = null!;
        Type = NotificationType.Default;
        Message = null!;
        CreatedAt = default!;
    }

    public Guid UserId { get; private set; }
    public AssignmentId AssignmentId { get; private set; }
    public NotificationType Type { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Notification Create(Guid userId, AssignmentId assignmentId, NotificationType type, string message,
        DateTime createdAt)
    {
        return new Notification(userId, assignmentId, type, message, createdAt);
    }
}