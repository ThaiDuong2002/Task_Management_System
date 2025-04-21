using Backend.Domain.Common.Models;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.NotificationModel.ValueObjects;

namespace Backend.Domain.Models.NotificationModel;

public class Notification : Entity<NotificationId>
{
    private Notification(Guid userId, AssignmentId assignmentId, NotificationType type, string message,
        bool isRead, DateTime scheduledTime, DateTime createdAt, DateTime updatedAt) : base(
        NotificationId.CreateUnique())
    {
        UserId = userId;
        AssignmentId = assignmentId;
        Type = type;
        Message = message;
        IsRead = isRead;
        ScheduledTime = scheduledTime;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Notification() : base(null!)
    {
        UserId = Guid.Empty;
        AssignmentId = null!;
        Type = NotificationType.Default;
        IsRead = false;
        Message = null!;
        CreatedAt = default!;
        UpdatedAt = default!;
    }

    public Guid UserId { get; private set; }
    public AssignmentId AssignmentId { get; private set; }
    public NotificationType Type { get; private set; }
    public string Message { get; private set; }
    public bool IsRead { get; private set; }
    public DateTime ScheduledTime { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Notification Create(Guid userId, AssignmentId assignmentId, NotificationType type, string message,
        bool isRead, DateTime scheduledTime, DateTime createdAt, DateTime updatedAt)
    {
        return new Notification(userId, assignmentId, type, message, isRead, scheduledTime, createdAt, updatedAt);
    }

    public void UpdateReadStatus(bool isRead)
    {
        IsRead = isRead;
        UpdatedAt = DateTime.UtcNow;
    }
}