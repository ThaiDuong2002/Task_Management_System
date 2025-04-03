using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.UserModel;
using Backend.Infrastructure.Authentication.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _dbContext;

    public UserRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid?> Create(User user)
    {
        var userIdentity = new UserIdentity
        {
            UserName = user.UserName,
            Email = user.Email,
            NormalizedEmail = user.Email.ToUpper(),
            NormalizedUserName = user.UserName.ToUpper(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            PasswordHash = user.PasswordHash
        };

        var result = await _dbContext.Users.AddAsync(userIdentity);
        var flag = await _dbContext.SaveChangesAsync();
        
        if (flag == 0)
            return null;
        
        return result.Entity.Id;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (result == null)
            return null;

        return new User
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Email = result.Email!,
            UserName = result.UserName!,
            PasswordHash = result.PasswordHash!
        };
    }

    public async Task<User?> GetById(Guid id)
    {
        var result = await _dbContext.Users
            .Include(u => u.Assignments)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (result == null)
            return null;

        return new User
        {
            Id = result.Id,
            Email = result.Email!,
            FirstName = result.FirstName,
            LastName = result.LastName,
            UserName = result.UserName!,
            PasswordHash = result.PasswordHash!
        };
    }
}