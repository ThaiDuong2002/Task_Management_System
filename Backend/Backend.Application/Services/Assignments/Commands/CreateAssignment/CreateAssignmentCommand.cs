using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.CreateAssignment;

public record CreateAssignmentCommand(
    Guid UserId,
    string Title,
    string? Description,
    string? Status,
    string? Priority,
    DateTime? DueDate
) : IRequest<ErrorOr<Assignment>>;