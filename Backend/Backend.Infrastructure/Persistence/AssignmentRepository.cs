using Backend.Application.Assignments.Commands.UpdateAssignment;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.AssignmentAggregate;
using Backend.Domain.AssignmentAggregate.ValueObjects;

namespace Backend.Infrastructure.Persistence;

public class AssignmentRepository : IAssignmentRepository
{
    private static readonly List<Assignment> _assignments = new();

    public void Add(Assignment assignment)
    {
        _assignments.Add(assignment);
    }

    public Guid? Update(UpdateAssignmentCommand command)
    {
        var existingAssignment = _assignments.FirstOrDefault(a => a.Id.Value == command.Id);

        if (existingAssignment is null) return null;

        existingAssignment.Update(
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate,
            DateTime.UtcNow
        );

        return existingAssignment.Id.Value;
    }
}