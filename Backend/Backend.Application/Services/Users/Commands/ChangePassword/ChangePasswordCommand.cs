using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.ChangePassword;

public record ChangePasswordCommand(
    Guid UserId,
    string OldPassword,
    string NewPassword
) : IRequest<ErrorOr<ChangePasswordResult>>;