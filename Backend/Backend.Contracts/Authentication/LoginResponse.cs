using Backend.Contracts.Users;

namespace Backend.Contracts.Authentication;

public record LoginResponse
{
    public required UserResponse User { get; set; }
    public required TokenResponse Token { get; set; }
}