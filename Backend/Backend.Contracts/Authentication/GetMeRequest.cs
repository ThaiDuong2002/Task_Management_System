namespace Backend.Contracts.Authentication;

public record GetMeRequest(
    string AccessToken,
    string RefreshToken
);