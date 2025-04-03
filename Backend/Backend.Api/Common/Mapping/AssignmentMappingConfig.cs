using Backend.Contracts.Assignments;
using Backend.Domain.Models.AssignmentModel;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class AssignmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Assignment, AssignmentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Status, src => src.Status.Value)
            .Map(dest => dest.Priority, src => src.Priority.Value)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.DueDate, src => src.DueDate)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
    }
}