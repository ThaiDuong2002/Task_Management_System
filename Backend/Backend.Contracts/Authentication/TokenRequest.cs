namespace Backend.Contracts.Authentication;

public record TokenRequest(
    string AccessToken,
    string RefreshToken
);