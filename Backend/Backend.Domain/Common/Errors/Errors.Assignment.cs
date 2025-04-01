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
    }
}