using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Queries.GetAssignment;

public class GetAssignmentQueryHandler : IRequestHandler<GetAssignmentQuery, ErrorOr<Assignment>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public GetAssignmentQueryHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<Assignment>> Handle(GetAssignmentQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var assignment = _assignmentRepository.GetById(query.Id);

        if (assignment is null) return Error.NotFound("Assignment not found");

        return assignment;
    }
}