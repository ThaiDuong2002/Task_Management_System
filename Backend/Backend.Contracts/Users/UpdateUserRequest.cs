namespace Backend.Contracts.Users;

public record UpdateUserRequest(
    string? FirstName,
    string? LastName,
    string? UserName
);