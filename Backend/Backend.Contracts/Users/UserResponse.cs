namespace Backend.Contracts.Users;

public record UserResponse(
    Guid Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email
);