using Backend.Domain.Models.UserModel;
using Backend.Domain.Models.UserModel.ValueObjects;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetById(UserId id);
    Task<int> Create(User user);
}