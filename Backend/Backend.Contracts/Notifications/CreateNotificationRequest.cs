namespace Backend.Contracts.Notifications;

public record CreateNotificationRequest(
    string UserId,
    string AssignmentId,
    string Type,
    string Message
);