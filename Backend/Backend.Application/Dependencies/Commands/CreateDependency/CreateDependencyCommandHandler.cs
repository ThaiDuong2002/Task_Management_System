using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.AssignmentAggregate.ValueObjects;
using Backend.Domain.DependencyAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Dependencies.Commands.CreateDependency;

public class CreateDependencyCommandHandler : IRequestHandler<CreateDependencyCommand, ErrorOr<Dependency>>
{
    private readonly IDependencyRepository _dependencyRepository;

    public CreateDependencyCommandHandler(IDependencyRepository dependencyRepository)
    {
        _dependencyRepository = dependencyRepository;
    }

    public async Task<ErrorOr<Dependency>> Handle(CreateDependencyCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dependency = Dependency.Create(
            AssignmentId.Create(command.AssignmentId),
            AssignmentId.Create(command.DependOnAssignmentId)
        );

        _dependencyRepository.Create(dependency);

        return dependency;
    }
}