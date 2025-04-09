using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<ErrorOr<UserResult>>;