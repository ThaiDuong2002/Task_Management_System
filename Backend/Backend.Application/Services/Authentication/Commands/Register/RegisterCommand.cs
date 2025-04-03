using Backend.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Commands.Register;

public record RegisterCommand(
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;