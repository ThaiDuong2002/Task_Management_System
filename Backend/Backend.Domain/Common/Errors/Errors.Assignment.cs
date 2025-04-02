using ErrorOr;

namespace Backend.Domain.Common.Errors;

public static partial class Errors
{
    public static class Assignment
    {
        public static Error NotFound => Error.NotFound(
            "Assignment.NotFound",
            "Assignment not found."
        );

        public static Error DependentNotFound => Error.NotFound(
            "Assignment.DependentNotFound",
            "Dependent Assignment not found."
        );

        public static Error UserNotFound => Error.NotFound(
            "Assignment.UserNotFound",
            "User not found."
        );

        public static Error CreateFailed => Error.Failure(
            "Assignment.CreateFailed",
            "Failed to create assignment."
        );

        public static Error DeleteFailed => Error.Failure(
            "Assignment.DeleteFailed",
            "Failed to delete assignment."
        );

        public static Error UpdateFailed => Error.Failure(
            "Assignment.UpdateFailed",
            "Failed to update assignment."
        );
    }
}