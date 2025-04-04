using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.DependencyModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Dependencies.Queries.GetDependencies;

public class GetDependenciesQueryHandler : IRequestHandler<GetDependenciesQuery, ErrorOr<List<Dependency>>>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IDependencyRepository _dependencyRepository;

    public GetDependenciesQueryHandler(IDependencyRepository dependencyRepository,
        IAssignmentRepository assignmentRepository)
    {
        _dependencyRepository = dependencyRepository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<ErrorOr<List<Dependency>>> Handle(GetDependenciesQuery query, CancellationToken cancellationToken)
    {
        // Check if the assignment exists
        var assignment = await _assignmentRepository.GetById(query.Id);

        if (assignment is null) return Errors.Assignment.NotFound;

        // Get the dependencies for the assignment
        var dependencies = await _dependencyRepository.GetByAssignmentId(query.Id, query.page, query.limit);

        return dependencies;
    }
}