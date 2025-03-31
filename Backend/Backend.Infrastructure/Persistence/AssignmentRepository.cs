using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.AssignmentAggregate;

namespace Backend.Infrastructure.Persistence;

public class AssignmentRepository : IAssignmentRepository
{
    private static readonly List<Assignment> _assignments = new();

    public void Add(Assignment assignment)
    {
        _assignments.Add(assignment);
    }
}