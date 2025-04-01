using Backend.Domain.DependencyAggregate;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IDependencyRepository
{
    void Create(Dependency dependency);
    int Delete(Dependency dependency);
}