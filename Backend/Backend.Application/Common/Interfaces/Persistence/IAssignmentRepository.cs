using System.Collections.ObjectModel;
using Backend.Application.Assignments.Commands.DeleteAssignment;
using Backend.Application.Assignments.Commands.UpdateAssignment;
using Backend.Domain.AssignmentAggregate;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IAssignmentRepository
{
    Assignment? GetById(Guid id);
    ReadOnlyCollection<Assignment> GetAll(int? page, int? limit, string? status, string? priority);
    void Create(Assignment assignment);
    Guid? Update(UpdateAssignmentCommand command);
    Guid? Delete(DeleteAssignmentCommand command);
}