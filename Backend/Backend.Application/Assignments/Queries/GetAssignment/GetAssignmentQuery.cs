using Backend.Domain.AssignmentAggregate;
using ErrorOr;
using MediatR;

namespace Backend.Application.Assignments.Queries.GetAssignment;

public record GetAssignmentQuery(
    Guid Id
) : IRequest<ErrorOr<Assignment>>;