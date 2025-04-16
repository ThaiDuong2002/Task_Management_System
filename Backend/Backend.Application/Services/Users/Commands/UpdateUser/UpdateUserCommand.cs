using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    string? FirstName,
    string? LastName,
    string? UserName
) : IRequest<ErrorOr<UpdateUserResult>>;