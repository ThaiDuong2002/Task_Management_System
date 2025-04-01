using Backend.Application.Services.Assignments.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.DeleteAssignment;

public record DeleteAssignmentCommand(
    Guid Id
) : IRequest<ErrorOr<ModifyAssignmentResult>>;