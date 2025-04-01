using Backend.Domain.Models.User;

namespace Backend.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}