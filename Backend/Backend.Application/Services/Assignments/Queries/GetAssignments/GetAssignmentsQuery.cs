using System.Collections.ObjectModel;
using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Queries.GetAssignments;

public record GetAssignmentsQuery(
    int? Page,
    int? Limit,
    string? Status,
    string? Priority
) : IRequest<ErrorOr<ReadOnlyCollection<Assignment>>>;