using Backend.Domain.Models.UserModel;

namespace Backend.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string? AccessToken = null,
    string? RefreshToken = null
);