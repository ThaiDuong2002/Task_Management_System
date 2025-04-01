using System.Collections.ObjectModel;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Assignments.Commands.DeleteAssignment;
using Backend.Application.Services.Assignments.Commands.UpdateAssignment;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;

namespace Backend.Infrastructure.Persistence.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private static readonly List<Assignment> _assignments = new();
    // private readonly PostgresDbContext _dbContext;

    public Guid? Update(UpdateAssignmentCommand command)
    {
        var existingAssignment = _assignments.FirstOrDefault(a => a.Id.Value == command.Id);

        if (existingAssignment is null) return null;

        existingAssignment.Update(
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate
        );

        return existingAssignment.Id.Value;
    }

    public Guid? Delete(DeleteAssignmentCommand command)
    {
        var existingAssignment = _assignments.FirstOrDefault(a => a.Id.Value == command.Id);

        if (existingAssignment is null) return null;

        _assignments.Remove(existingAssignment);

        return existingAssignment.Id.Value;
    }

    public Assignment? GetById(Guid id)
    {
        return _assignments.FirstOrDefault(a => a.Id.Value == id);
    }

    public void Create(Assignment assignment)
    {
        _assignments.Add(assignment);
    }

    public ReadOnlyCollection<Assignment> GetAll(int? page, int? limit, string? status, string? priority)
    {
        var assignments = _assignments.AsQueryable();

        if (status is not null) assignments = assignments.Where(a => a.Status.ToString() == status);

        if (priority is not null) assignments = assignments.Where(a => a.Priority.ToString() == priority);

        if (page.HasValue && limit.HasValue)
            assignments = assignments.Skip((page.Value - 1) * limit.Value).Take(limit.Value);

        return assignments.ToList().AsReadOnly();
    }
}