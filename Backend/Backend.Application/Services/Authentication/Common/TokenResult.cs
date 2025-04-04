namespace Backend.Application.Services.Authentication.Common;

public record TokenResult(
    string AccessToken,
    string RefreshToken
);