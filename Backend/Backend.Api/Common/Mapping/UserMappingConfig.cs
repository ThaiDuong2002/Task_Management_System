using Backend.Application.Services.Users.Common;
using Backend.Contracts.Users;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email);

        config.NewConfig<UpdateUserResult, UpdateUserResponse>()
            .Map(dest => dest.Id, src => src.Id);
    }
}