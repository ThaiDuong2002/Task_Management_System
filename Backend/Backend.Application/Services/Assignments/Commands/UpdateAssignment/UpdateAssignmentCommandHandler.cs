using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Assignments.Common;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.UpdateAssignment;

public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, ErrorOr<ModifyAssignmentResult>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public UpdateAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<ModifyAssignmentResult>> Handle(UpdateAssignmentCommand command,
        CancellationToken cancellationToken)
    {
        // Check if the assignment exists
        var assignment = await _assignmentRepository.GetById(command.Id);
        if (assignment is null) return Errors.Assignment.NotFound;

        // Update the assignment
        assignment.Update(
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate
        );

        // Save changes to the database
        var result = await _assignmentRepository.Update(assignment);

        if (result == 0) return Errors.Assignment.UpdateFailed;

        // Return the result
        return new ModifyAssignmentResult(assignment.Id.Value);
    }
}