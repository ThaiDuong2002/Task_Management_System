using Backend.Application.Services.Authentication.Common;
using Backend.Contracts.Authentication;
using Mapster;

namespace Backend.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Id, src => src.User.Id.Value);
    }
}