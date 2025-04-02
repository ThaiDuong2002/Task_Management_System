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
        // Check if the assignment exists
        var assignment = await _assignmentRepository.GetById(command.Id);

        if (assignment is null) return Errors.Assignment.NotFound;

        // Delete the assignment
        var result = await _assignmentRepository.Delete(assignment);

        if (result == 0) return Errors.Assignment.DeleteFailed;

        // Return the result
        return new ModifyAssignmentResult(assignment.Id.Value);
    }
}