using Backend.Application.Services.Authentication.Common;
using Backend.Application.Services.Authentication.Commands;
using Backend.Application.Services.Authentication.Queries;
using Backend.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService,
        IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationCommandService.Register(
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
        var authResult = _authenticationQueryService.Login(
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