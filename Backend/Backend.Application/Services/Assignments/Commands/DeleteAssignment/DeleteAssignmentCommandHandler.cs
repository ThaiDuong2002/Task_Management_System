using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Assignments.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.DeleteAssignment;

public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, ErrorOr<ModifyAssignmentResult>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public DeleteAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<ModifyAssignmentResult>> Handle(DeleteAssignmentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _assignmentRepository.Delete(command);

        if (result == 0) return Errors.Assignment.NotFound;

        return new ModifyAssignmentResult(command.Id);
    }
}