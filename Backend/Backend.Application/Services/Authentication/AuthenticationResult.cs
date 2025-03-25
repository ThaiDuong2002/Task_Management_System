using Backend.Domain.Entities;

namespace Backend.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
