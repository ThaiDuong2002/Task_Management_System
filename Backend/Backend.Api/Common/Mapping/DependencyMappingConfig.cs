using Backend.Contracts.Dependencies;
using Backend.Domain.Models.DependencyModel;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class DependencyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Dependency, DependencyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AssignmentId, src => src.AssignmentId.Value)
            .Map(dest => dest.DependOnAssignmentId, src => src.DependOnAssignmentId.Value);
    }
}