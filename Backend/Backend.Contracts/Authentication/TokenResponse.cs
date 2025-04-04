namespace Backend.Contracts.Authentication;

public record TokenResponse(
    string AccessToken,
    string RefreshToken
);