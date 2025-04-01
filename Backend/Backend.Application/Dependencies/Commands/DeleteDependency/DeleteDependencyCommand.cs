using ErrorOr;
using MediatR;

namespace Backend.Application.Dependencies.Commands.DeleteDependency;

public record DeleteDependencyCommand(
    Guid AssignmentId,
    Guid DependOnAssignmentId
) : IRequest<ErrorOr<int>>;