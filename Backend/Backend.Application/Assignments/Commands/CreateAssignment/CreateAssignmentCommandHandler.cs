using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.AssignmentAggregate;
using Backend.Domain.AssignmentAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Commands.CreateAssignment;

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
            command.DueDate,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        _assignmentRepository.Add(assignment);

        return assignment;
    }
}