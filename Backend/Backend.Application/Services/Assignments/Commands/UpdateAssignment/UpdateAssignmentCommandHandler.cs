using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Assignments.Common;
using Backend.Domain.Common.Errors;
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

    public async Task<ErrorOr<ModifyAssignmentResult>> Handle(UpdateAssignmentCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var result = _assignmentRepository.Update(request);

        if (result is null) return Errors.Assignment.NotFound;

        return new ModifyAssignmentResult(result.Value);
    }
}