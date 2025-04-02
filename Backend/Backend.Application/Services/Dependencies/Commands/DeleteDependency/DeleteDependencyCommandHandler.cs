using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Commands.DeleteDependency;

public class DeleteDependencyCommandHandler : IRequestHandler<DeleteDependencyCommand, ErrorOr<int>>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IDependencyRepository _dependencyRepository;

    public DeleteDependencyCommandHandler(IDependencyRepository dependencyRepository,
        IAssignmentRepository assignmentRepository)
    {
        _dependencyRepository = dependencyRepository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<int>> Handle(DeleteDependencyCommand command, CancellationToken cancellationToken)
    {
        // Check if the assignment exists
        var assignment = await _assignmentRepository.GetById(command.AssignmentId);
        if (assignment is null) return Errors.Assignment.NotFound;
        // Check if the dependent assignment exists
        var dependentAssignment = await _assignmentRepository.GetById(command.DependOnAssignmentId);
        if (dependentAssignment is null) return Errors.Assignment.DependentNotFound;

        // Check if the dependency exists
        var dependencies = await _dependencyRepository.GetAll(command.AssignmentId);
        var existingDependency =
            dependencies.FirstOrDefault(d => d.DependOnAssignmentId.Value == command.DependOnAssignmentId);

        if (existingDependency is null) return Errors.Dependency.NotFound;

        var result = await _dependencyRepository.Delete(existingDependency);

        if (result == 0) return Errors.Dependency.DeleteFailed;

        return result;
    }
}