using Backend.Domain.Entities;

namespace Backend.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);