﻿using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Common.Interfaces.Services;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly PostgresDbContext _dbContext;
    private readonly ILoggerService _logger;

    public AssignmentRepository(PostgresDbContext dbContext,
        ILoggerService logger
    )
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<int> Update(Assignment assignment)
    {
        _logger.LogInformation($"Updating assignment with id: {assignment.Id}");

        _dbContext.Assignments.Update(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Assignment assignment)
    {
        _logger.LogInformation($"Deleting assignment with id: {assignment.Id}");

        _dbContext.Assignments.Remove(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Assignment?> GetById(Guid id)
    {
        _logger.LogInformation($"Getting assignment with id: {id}");

        var assignmentId = AssignmentId.Create(id);
        return await _dbContext.Assignments.FirstOrDefaultAsync(a => a.Id == assignmentId);
    }

    public async Task<int> Create(Assignment assignment)
    {
        _logger.LogInformation($"Creating assignment with id: {assignment.Id}");

        await _dbContext.Assignments.AddAsync(assignment);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Assignment>> GetAll(Guid id, int? page, int? limit, string? status, string? priority,
        string? options)
    {
        _logger.LogInformation(
            $"Getting all assignments with status: {status}, priority: {priority}, page: {page}, limit: {limit}");

        var query = _dbContext.Assignments.AsQueryable();

        query = query.Where(a => a.UserId == id);

        if (options == "upcoming") query = query.Where(a => a.DueDate > DateTime.UtcNow);

        if (options == "overdue") query = query.Where(a => a.DueDate < DateTime.UtcNow);

        if (options == "today")
            query = query
                .Where(a => a.DueDate.Date == DateTime.UtcNow.Date)
                .Where(a => a.DueDate > DateTime.UtcNow);

        if (status is not null) query = query.Where(a => a.Status == Status.Create(status));

        if (priority is not null) query = query.Where(a => a.Priority == Priority.Create(priority));

        query = query.OrderByDescending(a => a.CreatedAt);

        if (page.HasValue && limit.HasValue) query = query.Skip((page.Value - 1) * limit.Value).Take(limit.Value);

        return await query.ToListAsync();
    }
}