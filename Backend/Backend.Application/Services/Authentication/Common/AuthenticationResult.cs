using Backend.Domain.Models.User;

namespace Backend.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);