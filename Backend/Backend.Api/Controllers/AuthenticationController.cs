using Backend.Application.Services.Authentication;
using Backend.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return authResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );

        return authResult.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return response;
    }
}