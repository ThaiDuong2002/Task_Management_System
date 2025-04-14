using ErrorOr;

namespace Backend.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            "User.DuplicateEmail",
            "Email is already in use."
        );

        public static Error DuplicateUserName => Error.Conflict(
            "User.DuplicateUserName",
            "Username is already in use."
        );

        public static Error FailedToRegister => Error.Failure(
            "User.FailedToRegister",
            "Failed to register user."
        );

        public static Error InvalidCredentials => Error.Validation(
            "User.InvalidCredentials",
            "Invalid credentials."
        );

        public static Error NotFound => Error.NotFound(
            "User.NotFound",
            "User not found."
        );

        public static Error UpdateFailed => Error.Failure(
            "User.UpdateFailed",
            "Failed to update user."
        );
    }
}