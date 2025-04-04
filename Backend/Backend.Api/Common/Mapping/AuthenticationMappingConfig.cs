using Backend.Application.Services.Authentication.Common;
using Backend.Contracts.Authentication;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, LoginResponse>()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken)
            .Map(dest => dest.UserName, src => src.User.UserName)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Id, src => src.User.Id);

        config.NewConfig<AuthenticationResult, RegisterResponse>()
            .Map(dest => dest.UserName, src => src.User.UserName)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Id, src => src.User.Id);
    }
}