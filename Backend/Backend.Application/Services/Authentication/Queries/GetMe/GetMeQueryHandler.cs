using System.Security.Claims;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Authentication.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Queries.GetMe;

public class GetMeQueryHandler : IRequestHandler<GetMeQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public GetMeQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(GetMeQuery query, CancellationToken cancellationToken)
    {
        var accessToken = query.AccessToken;
        var refreshToken = query.RefreshToken;

        // Determine if the access token is expired
        var principal = _jwtTokenGenerator.IsTokenExpired(accessToken)
            ? _jwtTokenGenerator.GetPrincipalFromExpiredToken(accessToken)
            : _jwtTokenGenerator.GetPrincipalFromToken(accessToken);

        var userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Errors.Authentication.InvalidToken;

        // Fetch user from the database
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if (user == null) return Errors.Authentication.InvalidToken;

        // Verify refresh token validity
        var storedRefreshToken = await _userRepository.GetRefreshToken(user.Id!.Value.ToString());
        if (storedRefreshToken == null || storedRefreshToken != refreshToken)
            return Errors.Authentication.InvalidToken;

        // Check if refresh token is expired
        if (_jwtTokenGenerator.IsTokenExpired(refreshToken)) return Errors.Authentication.Unauthorized;

        // Generate new access token and refresh token
        if (_jwtTokenGenerator.IsTokenExpired(query.AccessToken)) accessToken = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, new TokenResult(accessToken, refreshToken));
    }
}