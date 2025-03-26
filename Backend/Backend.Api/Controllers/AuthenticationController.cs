using Backend.Application.Services.Authentication;
using Backend.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
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

        return authResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
            firstError => Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Description)
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

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );

        return authResult.MatchFirst(
            result => Ok(MapAuthResult(result)),
            firstError => Problem(statusCode: StatusCodes.Status401Unauthorized, detail: firstError.Description)
        );
    }
}