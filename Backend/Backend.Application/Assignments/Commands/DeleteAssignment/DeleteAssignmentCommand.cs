using Backend.Application.Assignments.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Commands.DeleteAssignment;

public record DeleteAssignmentCommand(
    Guid Id
) : IRequest<ErrorOr<ModifyAssignmentResult>>;