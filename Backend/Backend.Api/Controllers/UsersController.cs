using Backend.Application.Services.Users.Commands.ChangePassword;
using Backend.Application.Services.Users.Commands.UpdateUser;
using Backend.Application.Services.Users.Queries.GetUserByEmail;
using Backend.Application.Services.Users.Queries.GetUserById;
using Backend.Contracts.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/users")]
public class UsersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public UsersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));

        return result.Match(
            user => Ok(_mapper.Map<UserResponse>(user)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var result = await _mediator.Send(new GetUserByEmailQuery(email));

        return result.Match(
            user => Ok(_mapper.Map<UserResponse>(user)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest request)
    {
        var result =
            await _mediator.Send(new UpdateUserCommand(id, request.FirstName, request.LastName, request.UserName));

        return result.Match(
            user => Ok(_mapper.Map<UpdateUserResponse>(user)),
            errors => Problem(errors)
        );
    }

    [HttpPut("password/{id}")]
    public async Task<IActionResult> UpdateUserPassword(Guid id, ChangePasswordRequest request)
    {
        var result = await _mediator.Send(new ChangePasswordCommand(id, request.OldPassword, request.NewPassword));

        return result.Match(
            user => Ok(_mapper.Map<ChangePasswordResponse>(user)),
            errors => Problem(errors)
        );
    }
}