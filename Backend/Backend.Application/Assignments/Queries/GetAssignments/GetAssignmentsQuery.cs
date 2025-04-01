using System.Collections.ObjectModel;
using Backend.Domain.AssignmentAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Queries.GetAssignments;

public record GetAssignmentsQuery(
    int? Page,
    int? Limit,
    string? Status,
    string? Priority
) : IRequest<ErrorOr<ReadOnlyCollection<Assignment>>>;