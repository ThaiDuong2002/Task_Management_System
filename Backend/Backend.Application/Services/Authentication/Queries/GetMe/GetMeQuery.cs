using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Queries.GetMe;

public record GetMeQuery(string token) : IRequest<ErrorOr<UserResult>>;