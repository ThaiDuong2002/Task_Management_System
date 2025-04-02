using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class DependencyRepository : IDependencyRepository
{
    private readonly PostgresDbContext _dbContext;

    public DependencyRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(Dependency dependency)
    {
        await _dbContext.Dependencies.AddAsync(dependency);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Dependency dependency)
    {
        Console.WriteLine(dependency.AssignmentId.Value);
        _dbContext.Dependencies.Remove(dependency);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Dependency>> GetAll()
    {
        return await _dbContext.Dependencies.ToListAsync();
    }

    public async Task<List<Dependency>> GetByAssignmentId(Guid id)
    {
        return await _dbContext.Dependencies
            .Where(d => d.AssignmentId == AssignmentId.Create(id))
            .ToListAsync();
    }
}