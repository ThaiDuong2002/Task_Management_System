namespace Backend.Contracts.Notifications;

public record NotificationResponse(
    Guid Id,
    string UserId,
    string AssignmentId,
    string Message,
    string Type,
    bool IsRead,
    DateTime ScheduledTime,
    DateTime CreatedAt,
    DateTime UpdatedAt
);