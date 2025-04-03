namespace Backend.Contracts.Notifications;

public record NotificationResponse(
    Guid Id,
    string UserId,
    string AssignmentId,
    string Message,
    string Type,
    DateTime CreatedAt
);