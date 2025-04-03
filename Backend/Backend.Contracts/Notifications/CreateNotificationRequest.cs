namespace Backend.Contracts.Notifications;

public record CreateNotificationRequest(
    Guid UserId,
    string AssignmentId,
    string Type,
    string Message
);