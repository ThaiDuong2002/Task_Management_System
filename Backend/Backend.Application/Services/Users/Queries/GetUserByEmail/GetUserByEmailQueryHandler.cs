using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(query.Email);

        if (user is null) return Errors.User.NotFound;

        return new UserResult(
            user.Id!.Value,
            user.FirstName,
            user.LastName,
            user.Email,
            user.UserName,
            user.CreatedAt,
            user.UpdatedAt
        );
    }
}