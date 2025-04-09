using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.Id);

        if (user == null)
            return Errors.User.NotFound;

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