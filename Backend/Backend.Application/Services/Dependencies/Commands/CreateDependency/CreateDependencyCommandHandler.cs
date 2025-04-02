using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.DependencyModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Commands.CreateDependency;

public class CreateDependencyCommandHandler : IRequestHandler<CreateDependencyCommand, ErrorOr<Dependency>>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IDependencyRepository _dependencyRepository;

    public CreateDependencyCommandHandler(IDependencyRepository dependencyRepository,
        IAssignmentRepository assignmentRepository)
    {
        _dependencyRepository = dependencyRepository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<Dependency>> Handle(CreateDependencyCommand command, CancellationToken cancellationToken)
    {
        // Check if the assignment exists
        var assignment = await _assignmentRepository.GetById(command.AssignmentId);
        if (assignment is null) return Errors.Assignment.NotFound;
        // Check if the dependent assignment exists
        var dependentAssignment = await _assignmentRepository.GetById(command.DependOnAssignmentId);
        if (dependentAssignment is null) return Errors.Assignment.DependentNotFound;

        // Check if the dependency exists
        var dependencies = await _dependencyRepository.GetByAssignmentId(command.AssignmentId);
        var dependencyExists = dependencies.Any(d => d.DependOnAssignmentId.Value == command.DependOnAssignmentId);

        if (dependencyExists) return Errors.Dependency.AlreadyExists;

        var dependency = Dependency.Create(
            AssignmentId.Create(command.AssignmentId),
            AssignmentId.Create(command.DependOnAssignmentId)
        );

        var result = await _dependencyRepository.Create(dependency);

        if (result == 0) return Errors.Dependency.CreateFailed;

        return dependency;
    }
}