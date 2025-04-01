using Backend.Application.Assignments.Commands.UpdateAssignment;
using Backend.Domain.AssignmentAggregate;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IAssignmentRepository
{
    void Add(Assignment assignment);
    Guid? Update(UpdateAssignmentCommand command);
}