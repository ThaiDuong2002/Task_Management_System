using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.UserModel;
using Backend.Infrastructure.Authentication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostgresDbContext _dbContext;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<UserIdentity> _userManager;

    public UserRepository(
        PostgresDbContext dbContext,
        UserManager<UserIdentity> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
            PasswordHash = user.PasswordHash,
            SecurityStamp = Guid.NewGuid().ToString(),
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
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

    public async Task<User?> GetUserByUserName(string userName)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

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

    public async Task<User?> GetUserById(Guid id)
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
            PasswordHash = result.PasswordHash!,
            CreatedAt = result.CreatedAt,
            UpdatedAt = result.UpdatedAt
        };
    }

    public async Task<int> Update(User user)
    {
        var userIdentity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

        if (userIdentity == null)
            return 0;

        userIdentity.FirstName = user.FirstName;
        userIdentity.LastName = user.LastName;
        userIdentity.Email = user.Email;
        userIdentity.UserName = user.UserName;
        userIdentity.NormalizedUserName = user.UserName.ToUpper();
        userIdentity.UpdatedAt = DateTime.UtcNow;

        _dbContext.Users.Update(userIdentity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task StoreRefreshToken(string userId, string refreshToken)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.RemoveAuthenticationTokenAsync(user!, "RefreshTokenProvider", "RefreshToken");
        await _userManager.SetAuthenticationTokenAsync(user!, "RefreshTokenProvider", "RefreshToken", refreshToken);
    }

    public async Task DeleteRefreshToken(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.RemoveAuthenticationTokenAsync(user!, "RefreshTokenProvider", "RefreshToken");
    }

    public async Task<string?> GetRefreshToken(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return await _userManager.GetAuthenticationTokenAsync(user!, "RefreshTokenProvider", "RefreshToken");
    }

    public async Task<int> ChangePassword(string userId, string passwordHash)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) return 0;

        user.PasswordHash = passwordHash;
        user.SecurityStamp = Guid.NewGuid().ToString();

        _dbContext.Users.Update(user);
        return await _dbContext.SaveChangesAsync();
    }
}