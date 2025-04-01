using Backend.Domain.Models.DependencyModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Commands.CreateDependency;

public record CreateDependencyCommand(
    Guid AssignmentId,
    Guid DependOnAssignmentId
) : IRequest<ErrorOr<Dependency>>;