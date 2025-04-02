using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Assignments.Commands.DeleteAssignment;
using Backend.Application.Services.Assignments.Commands.UpdateAssignment;
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

    public async Task<int> Update(UpdateAssignmentCommand command)
    {
        var assignmentId = AssignmentId.Create(command.Id);
        var existingAssignment = await _dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == assignmentId);
        if (existingAssignment is null) return 0;

        existingAssignment.Update(
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate
        );

        _dbContext.Assignments.Update(existingAssignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(DeleteAssignmentCommand command)
    {
        var assignmentId = AssignmentId.Create(command.Id);
        var existingAssignment = await _dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == assignmentId);
        if (existingAssignment is null) return 0;

        _dbContext.Assignments.Remove(existingAssignment);
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