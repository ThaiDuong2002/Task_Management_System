namespace Backend.Contracts.Authentication;

public record RegisterResponse(
    Guid Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email
);