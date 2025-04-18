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
        var assignments =
            await _assignmentRepository.GetAll(query.Id, query.Page, query.Limit, query.Status, query.Priority,
                query.Options);

        return assignments;
    }
}