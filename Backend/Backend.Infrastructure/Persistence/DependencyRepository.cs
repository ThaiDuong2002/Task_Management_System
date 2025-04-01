using Backend.Application.Common.Interfaces.Persistence;
using Backend.Domain.DependencyAggregate;

namespace Backend.Infrastructure.Persistence;

public class DependencyRepository : IDependencyRepository
{
    private static readonly List<Dependency> _dependencies = new();

    public void Create(Dependency dependency)
    {
        _dependencies.Add(dependency);
    }

    public int Delete(Dependency dependency)
    {
        var existingDependency = _dependencies.FirstOrDefault(
            d => d.AssignmentId == dependency.AssignmentId
                 && d.DependOnAssignmentId == dependency.DependOnAssignmentId
        );

        if (existingDependency is null) return 0;

        _dependencies.Remove(existingDependency);

        return 1;
    }
}