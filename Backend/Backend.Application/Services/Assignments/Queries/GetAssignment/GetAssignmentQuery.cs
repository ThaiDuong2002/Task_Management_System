using Backend.Domain.Models.AssignmentModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Assignments.Queries.GetAssignment;

public record GetAssignmentQuery(
    Guid Id
) : IRequest<ErrorOr<Assignment>>;