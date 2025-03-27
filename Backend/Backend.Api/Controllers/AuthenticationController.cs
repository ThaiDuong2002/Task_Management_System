using Backend.Application.Authentication.Commands.Register;
using Backend.Application.Authentication.Queries.Login;
using Backend.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/auth")]
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
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
        );
    }
}