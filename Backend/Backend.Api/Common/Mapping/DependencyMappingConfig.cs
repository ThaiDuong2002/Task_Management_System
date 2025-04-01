using Backend.Application.Dependencies.Commands.CreateDependency;
using Backend.Application.Dependencies.Commands.DeleteDependency;
using Backend.Contracts.Dependencies;
using Backend.Domain.DependencyAggregate;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class DependencyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid assignmentId, CreateDependencyRequest request), CreateDependencyCommand>()
            .Map(dest => dest.AssignmentId, src => src.assignmentId)
            .Map(dest => dest.DependOnAssignmentId, src => src.request.DependOnAssignmentId);

        config.NewConfig<Dependency, DependencyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AssignmentId, src => src.AssignmentId.Value)
            .Map(dest => dest.DependOnAssignmentId, src => src.DependOnAssignmentId.Value);

        config.NewConfig<(Guid assignmentId, Guid dependencyId), DeleteDependencyCommand>()
            .Map(dest => dest.AssignmentId, src => src.assignmentId)
            .Map(dest => dest.DependOnAssignmentId, src => src.dependencyId);
    }
}