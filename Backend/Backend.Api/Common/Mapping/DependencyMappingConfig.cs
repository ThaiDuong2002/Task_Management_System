using Backend.Application.Services.Dependencies.Commands.CreateDependency;
using Backend.Application.Services.Dependencies.Commands.DeleteDependency;
using Backend.Application.Services.Dependencies.Queries.GetDependencies;
using Backend.Contracts.Dependencies;
using Backend.Domain.Models.DependencyModel;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class DependencyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid assignmentId, CreateDependencyRequest request), CreateDependencyCommand>()
            .Map(dest => dest.AssignmentId, src => src.assignmentId)
            .Map(dest => dest.DependOnAssignmentId, src => src.request.DependOnAssignmentId);

        config.NewConfig<(Guid assignmentId, int? page, int? limit), GetDependenciesQuery>()
            .Map(dest => dest.Id, src => src.assignmentId)
            .Map(dest => dest.page, src => src.page)
            .Map(dest => dest.limit, src => src.limit);

        config.NewConfig<Dependency, DependencyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AssignmentId, src => src.AssignmentId.Value)
            .Map(dest => dest.DependOnAssignmentId, src => src.DependOnAssignmentId.Value);

        config.NewConfig<(Guid assignmentId, Guid dependencyId), DeleteDependencyCommand>()
            .Map(dest => dest.AssignmentId, src => src.assignmentId)
            .Map(dest => dest.DependOnAssignmentId, src => src.dependencyId);
    }
}