using Backend.Domain.AssignmentAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Commands.CreateAssignment;

public record CreateAssignmentCommand(
    Guid UserId,
    string Title,
    string? Description,
    string? Status,
    string? Priority,
    DateTime DueDate
) : IRequest<ErrorOr<Assignment>>;