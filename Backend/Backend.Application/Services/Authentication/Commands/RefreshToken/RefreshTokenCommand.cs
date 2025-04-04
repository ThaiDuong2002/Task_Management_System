using Backend.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand(
    string AccessToken,
    string RefreshToken
) : IRequest<ErrorOr<TokenResult>>;