using Backend.Domain.User;

namespace Backend.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);