namespace Backend.Infrastructure.Authentication.Common;

public record Credentials(
    string Email,
    string Password
);