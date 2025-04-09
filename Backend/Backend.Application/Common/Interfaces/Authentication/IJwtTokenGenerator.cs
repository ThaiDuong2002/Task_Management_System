using System.Security.Claims;
using Backend.Domain.Models.UserModel;

namespace Backend.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
    bool IsTokenExpired(string token);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    ClaimsPrincipal? GetPrincipalFromToken(string token);
}