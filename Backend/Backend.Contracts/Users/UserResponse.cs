namespace Backend.Contracts.Authentication;

public record UserResponse(
    Guid Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email
);