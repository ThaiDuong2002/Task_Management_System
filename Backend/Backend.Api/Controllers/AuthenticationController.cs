using Backend.Application.Services.Authentication.Commands.RefreshToken;
using Backend.Application.Services.Authentication.Commands.Register;
using Backend.Application.Services.Authentication.Queries.GetMe;
using Backend.Application.Services.Authentication.Queries.Login;
using Backend.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await _mediator.Send(new RegisterCommand(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        ));

        return authResult.Match(
            result => Created(HttpContext.Request.Path, _mapper.Map<RegisterResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _mediator.Send(new LoginQuery(
            request.Email,
            request.Password
        ));

        return authResult.Match(
            result => Ok(_mapper.Map<LoginResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenRequest request)
    {
        var authResult = await _mediator.Send(new RefreshTokenCommand(
            request.AccessToken,
            request.RefreshToken
        ));

        return authResult.Match(
            result => Ok(_mapper.Map<TokenResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost("get-me")]
    public async Task<IActionResult> GetMe(GetMeRequest request)
    {
        var authResult = await _mediator.Send(new GetMeQuery(request.AccessToken, request.RefreshToken));

        return authResult.Match(
            result => Ok(_mapper.Map<LoginResponse>(result)),
            errors => Problem(errors)
        );
    }
}