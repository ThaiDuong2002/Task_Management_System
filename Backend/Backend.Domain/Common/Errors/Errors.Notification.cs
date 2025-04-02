using ErrorOr;

namespace Backend.Domain.Common.Errors;

public static partial class Errors
{
    public static class Notification
    {
        public static Error InvalidNotification => Error.Validation(
            "Notification.InvalidNotification",
            "Invalid notification."
        );

        public static Error NotificationNotFound => Error.NotFound(
            "Notification.NotificationNotFound",
            "Notification not found."
        );

        public static Error NotificationAlreadyExists => Error.Conflict(
            "Notification.NotificationAlreadyExists",
            "Notification already exists."
        );
    }
}