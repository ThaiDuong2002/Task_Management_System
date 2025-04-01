using Backend.Application.Assignments.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Commands.UpdateAssignment;

public record UpdateAssignmentCommand(
    Guid Id,
    string Title,
    string? Description,
    string Status,
    string Priority,
    DateTime DueDate
) : IRequest<ErrorOr<ModifyAssignmentResult>>;