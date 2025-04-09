using Backend.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Queries.GetMe;

public record GetMeQuery(
    string AccessToken,
    string RefreshToken
) : IRequest<ErrorOr<AuthenticationResult>>;