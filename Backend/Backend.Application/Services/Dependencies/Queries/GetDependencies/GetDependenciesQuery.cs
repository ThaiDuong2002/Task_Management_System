using Backend.Domain.Models.DependencyModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Queries.GetDependencies;

public record GetDependenciesQuery(
    Guid Id,
    int? page,
    int? limit
) : IRequest<ErrorOr<List<Dependency>>>;