using Backend.Application.Services.Authentication.Common;
using ErrorOr;

namespace Backend.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}