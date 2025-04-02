using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly PostgresDbContext _dbContext;

    public AssignmentRepository(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Update(Assignment assignment)
    {
        _dbContext.Assignments.Update(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Assignment assignment)
    {
        _dbContext.Assignments.Remove(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Assignment?> GetById(Guid id)
    {
        var assignmentId = AssignmentId.Create(id);
        return await _dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == assignmentId);
    }

    public async Task<int> Create(Assignment assignment)
    {
        await _dbContext.Assignments.AddAsync(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Assignment>> GetAll(int? page, int? limit, string? status, string? priority)
    {
        var query = _dbContext.Assignments.AsQueryable();

        if (status is not null) query = query.Where(a => a.Status.Value == status);

        if (priority is not null) query = query.Where(a => a.Priority.Value == priority);

        if (page.HasValue && limit.HasValue) query = query.Skip((page.Value - 1) * limit.Value).Take(limit.Value);

        return await query.ToListAsync();
    }
}