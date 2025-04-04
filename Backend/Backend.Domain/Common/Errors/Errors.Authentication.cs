using ErrorOr;

namespace Backend.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            "Auth.InvalidCred",
            "Invalid credentials."
        );

        public static Error InvalidToken => Error.Validation(
            "Auth.InvalidToken",
            "Invalid token."
        );

        public static Error Unauthorized => Error.Unauthorized(
            "Auth.Unauthorized",
            "Unauthorized."
        );
    }
}