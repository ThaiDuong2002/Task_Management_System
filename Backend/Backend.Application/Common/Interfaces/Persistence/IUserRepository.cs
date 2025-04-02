using Backend.Domain.Models.UserModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    Task<int> AddAsync(User user);
}