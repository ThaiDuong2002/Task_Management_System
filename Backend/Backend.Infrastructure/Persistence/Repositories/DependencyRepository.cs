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
        _dbContext.Dependencies.Remove(dependency);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Dependency>> GetAll(Guid id)
    {
        var query = _dbContext.Dependencies.AsQueryable();

        var assignmentId = AssignmentId.Create(id);

        if (id != Guid.Empty) query = query.Where(d => d.AssignmentId == assignmentId);

        return await query.ToListAsync();
    }

    public async Task<List<Dependency>> GetByAssignmentId(Guid id, int? page, int? limit)
    {
        var query = _dbContext.Dependencies.AsQueryable();

        var assignmentId = AssignmentId.Create(id);

        if (id != Guid.Empty) query = query.Where(d => d.AssignmentId == assignmentId);

        if (page.HasValue && limit.HasValue) query = query.Skip((page.Value - 1) * limit.Value).Take(limit.Value);

        return await query.ToListAsync();
    }
}