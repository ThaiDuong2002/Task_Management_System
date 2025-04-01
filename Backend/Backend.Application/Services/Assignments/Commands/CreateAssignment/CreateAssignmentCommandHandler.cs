using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.CreateAssignment;

public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, ErrorOr<Assignment>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public CreateAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<Assignment>> Handle(CreateAssignmentCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var assignment = Assignment.Create(
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate
        );

        _assignmentRepository.Create(assignment);

        return assignment;
    }
}