using Backend.Contracts.Notifications;
using Backend.Domain.Models.NotificationModel;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class NotificationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Notification, NotificationResponse>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.AssignmentId, src => src.AssignmentId.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Type, src => src.Type.Value)
            .Map(dest => dest.Message, src => src.Message)
            .Map(dest => dest.IsRead, src => src.IsRead)
            .Map(dest => dest.ScheduledTime, src => src.ScheduledTime)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
    }
}