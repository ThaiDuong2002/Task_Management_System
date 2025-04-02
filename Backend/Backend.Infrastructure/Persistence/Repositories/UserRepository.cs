using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.UserModel;
using Backend.Domain.Models.UserModel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _dbContext;

    public UserRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetById(UserId id)
    {
        return await _dbContext.Users
            .Include(u => u.Assignments)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}