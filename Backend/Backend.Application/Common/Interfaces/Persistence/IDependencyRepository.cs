using Backend.Domain.Models.Dependency;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IDependencyRepository
{
    void Create(Dependency dependency);
    int Delete(Dependency dependency);
}