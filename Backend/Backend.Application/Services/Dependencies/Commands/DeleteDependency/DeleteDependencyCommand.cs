using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Commands.DeleteDependency;

public record DeleteDependencyCommand(
    Guid AssignmentId,
    Guid DependOnAssignmentId
) : IRequest<ErrorOr<int>>;