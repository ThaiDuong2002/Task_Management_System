using Backend.Application.Services.Assignments.Commands.DeleteAssignment;
using Backend.Application.Services.Assignments.Commands.UpdateAssignment;
using Backend.Domain.Models.AssignmentModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IAssignmentRepository
{
    Task<Assignment?> GetById(Guid id);
    Task<List<Assignment>> GetAll(int? page, int? limit, string? status, string? priority);
    Task<int> Create(Assignment assignment);
    Task<int> Update(UpdateAssignmentCommand command);
    Task<int> Delete(DeleteAssignmentCommand command);
}