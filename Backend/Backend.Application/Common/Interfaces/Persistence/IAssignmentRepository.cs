using Backend.Domain.AssignmentAggregate;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IAssignmentRepository
{
    void Add(Assignment assignment);
}