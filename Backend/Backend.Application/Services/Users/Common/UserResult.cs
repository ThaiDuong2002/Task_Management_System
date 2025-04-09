namespace Backend.Application.Services.Users.Common;

public record UserResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);