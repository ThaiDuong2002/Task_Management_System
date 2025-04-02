using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Queries.GetAssignments;

public class GetAssignmentsQueryHandler : IRequestHandler<GetAssignmentsQuery, ErrorOr<List<Assignment>>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public GetAssignmentsQueryHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<List<Assignment>>> Handle(GetAssignmentsQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var assignments = await _assignmentRepository.GetAll(query.Page, query.Limit, query.Status, query.Priority);

        return assignments;
    }
}