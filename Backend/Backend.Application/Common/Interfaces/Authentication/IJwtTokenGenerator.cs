using Backend.Domain.Models.UserModel;

namespace Backend.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}