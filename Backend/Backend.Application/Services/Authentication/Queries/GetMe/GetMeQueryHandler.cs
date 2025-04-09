using System.Security.Claims;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Queries.GetMe;

public class GetMeQueryHandler : IRequestHandler<GetMeQuery, ErrorOr<UserResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public GetMeQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetMeQuery query, CancellationToken cancellationToken)
    {
        var priciple = _jwtTokenGenerator.GetPrincipalFromExpiredToken(query.token);
        var userId = priciple?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null) return Errors.Authentication.InvalidToken;

        var user = await _userRepository.GetUserById(Guid.Parse(userId));

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