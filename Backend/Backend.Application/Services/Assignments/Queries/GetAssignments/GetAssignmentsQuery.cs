using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Queries.GetAssignments;

public record GetAssignmentsQuery(
    int? Page,
    int? Limit,
    string? Status,
    string? Priority
) : IRequest<ErrorOr<List<Assignment>>>;