using Backend.Domain.Models.AssignmentModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IAssignmentRepository
{
    Task<Assignment?> GetById(Guid id);
    Task<List<Assignment>> GetAll(Guid id, int? page, int? limit, string? status, string? priority);
    Task<int> Create(Assignment assignment);
    Task<int> Update(Assignment assignment);
    Task<int> Delete(Assignment assignment);
}