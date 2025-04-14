using Backend.Domain.Models.UserModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByUserName(string userName);
    Task<User?> GetUserById(Guid id);
    Task<Guid?> Create(User user);
    Task<int> Update(User user);
    Task StoreRefreshToken(string userId, string refreshToken);
    Task<string?> GetRefreshToken(string userId);
}