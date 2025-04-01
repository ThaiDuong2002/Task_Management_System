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
    }
}