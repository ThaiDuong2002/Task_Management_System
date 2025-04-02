using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.AssignmentModel;
using Backend.Domain.Models.AssignmentModel.ValueObjects;
using Backend.Domain.Models.UserModel.ValueObjects;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Commands.CreateAssignment;

public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, ErrorOr<Assignment>>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IUserRepository _userRepository;

    public CreateAssignmentCommandHandler(IAssignmentRepository assignmentRepository, IUserRepository userRepository)
    {
        _assignmentRepository = assignmentRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Assignment>> Handle(CreateAssignmentCommand command, CancellationToken cancellationToken)
    {
        // Check if the user exists
        var userResult = await _userRepository.GetById(UserId.Create(command.UserId));

        if (userResult is null) return Errors.User.NotFound;

        var assignment = Assignment.Create(
            UserId.Create(command.UserId),
            command.Title,
            command.Description,
            Status.Create(command.Status),
            Priority.Create(command.Priority),
            command.DueDate
        );

        await _assignmentRepository.Create(assignment);

        return assignment;
    }
}