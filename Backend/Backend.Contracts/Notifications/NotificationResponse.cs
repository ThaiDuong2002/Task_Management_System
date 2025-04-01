namespace Backend.Contracts.Notifications;

public record NotificationResponse(
    string Id,
    string UserId,
    string AssignmentId,
    string Message,
    string Type,
    DateTime CreatedAt
);