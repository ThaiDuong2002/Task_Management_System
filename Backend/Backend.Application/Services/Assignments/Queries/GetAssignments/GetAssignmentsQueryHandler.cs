using System.Collections.ObjectModel;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Queries.GetAssignments;

public class GetAssignmentsQueryHandler : IRequestHandler<GetAssignmentsQuery, ErrorOr<ReadOnlyCollection<Assignment>>>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public GetAssignmentsQueryHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<ReadOnlyCollection<Assignment>>> Handle(GetAssignmentsQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var assignments = _assignmentRepository.GetAll(query.Page, query.Limit, query.Status, query.Priority);

        return assignments;
    }
}