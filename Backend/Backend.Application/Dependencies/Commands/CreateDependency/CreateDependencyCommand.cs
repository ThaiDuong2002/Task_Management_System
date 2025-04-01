using Backend.Domain.DependencyAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Dependencies.Commands.CreateDependency;

public record CreateDependencyCommand(
    Guid AssignmentId,
    Guid DependOnAssignmentId
) : IRequest<ErrorOr<Dependency>>;