using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Queries.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<ErrorOr<UserResult>>;