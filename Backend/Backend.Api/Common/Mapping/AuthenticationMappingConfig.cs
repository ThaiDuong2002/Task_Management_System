using Backend.Application.Services.Authentication.Common;
using Backend.Contracts.Authentication;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, LoginResponse>()
            .Map(dest => dest.User.UserName, src => src.User.UserName)
            .Map(dest => dest.User.FirstName, src => src.User.FirstName)
            .Map(dest => dest.User.LastName, src => src.User.LastName)
            .Map(dest => dest.User.Email, src => src.User.Email)
            .Map(dest => dest.User.Id, src => src.User.Id)
            .Map(dest => dest.Token.AccessToken, src => src.TokenResult.AccessToken)
            .Map(dest => dest.Token.RefreshToken, src => src.TokenResult.RefreshToken);

        config.NewConfig<AuthenticationResult, RegisterResponse>()
            .Map(dest => dest.UserName, src => src.User.UserName)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Id, src => src.User.Id);
    }
}