using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.UserModel;

namespace Backend.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _dbContext;

    public UserRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }
}