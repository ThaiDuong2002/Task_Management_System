using Backend.Domain.Entities;

namespace Backend.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);