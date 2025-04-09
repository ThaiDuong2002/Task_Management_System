using System.Security.Claims;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Authentication.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ErrorOr<TokenResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RefreshTokenCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    )
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<TokenResult>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        // 1. Validate the access token
        var principal = _jwtTokenGenerator.GetPrincipalFromExpiredToken(command.AccessToken);
        var userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null) return Errors.Authentication.InvalidToken;

        // 2. Get the user from the database
        var user = await _userRepository.GetUserById(Guid.Parse(userId));

        if (user == null) return Errors.Authentication.InvalidToken;

        // 3. Check if the refresh token is valid
        var storedRefreshToken = await _userRepository.GetRefreshToken(user.Id!.Value.ToString());

        if (storedRefreshToken == null || storedRefreshToken != command.RefreshToken)
            return Errors.Authentication.InvalidToken;

        // 4. Check if the refresh token is expired
        var isExpired = _jwtTokenGenerator.IsTokenExpired(command.RefreshToken);

        if (isExpired) return Errors.Authentication.Unauthorized;

        // 5. Generate new access token and refresh token
        var newAccessToken = _jwtTokenGenerator.GenerateToken(user);
        var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        // 6. Store the new refresh token in the database
        await _userRepository.StoreRefreshToken(userId, newRefreshToken);

        // 7. Return the new access token and refresh token
        return new TokenResult(
            newAccessToken,
            newRefreshToken
        );
    }
}