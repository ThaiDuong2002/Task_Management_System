using ErrorOr;

namespace Backend.Domain.Common.Errors;

public static partial class Errors
{
    public static class Dependency
    {
        public static Error NotFound => Error.NotFound(
            "Dependency.NotFound",
            "Dependency not found."
        );

        public static Error AlreadyExists => Error.Conflict(
            "Dependency.AlreadyExists",
            "Dependency already exists."
        );

        public static Error CreateFailed => Error.Failure(
            "Dependency.CreateFailed",
            "Failed to create dependency."
        );

        public static Error DeleteFailed => Error.Failure(
            "Dependency.DeleteFailed",
            "Failed to delete dependency."
        );
    }
}