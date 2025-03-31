namespace Backend.Contracts.Notifications;

public record CreateNotificationRequest(
    string UserId,
    string TaskId,
    string Type,
    string Message
);