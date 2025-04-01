using Backend.Domain.Models.DependencyModel;

namespace Backend.Application.Common.Interfaces.Persistence;

public interface IDependencyRepository
{
    void Create(Dependency dependency);
    int Delete(Dependency dependency);
}