namespace Backend.Contracts.Authentication;

public record LoginResponse(
    Guid Id,
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string AccessToken,
    string RefreshToken
);