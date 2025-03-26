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
    }
}