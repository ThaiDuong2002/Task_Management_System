﻿using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Authentication.Common;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.UserModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ISecurePasswordProvider _securePasswordProvider;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository,
        ISecurePasswordProvider securePasswordProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _securePasswordProvider = securePasswordProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // 1. Validate the user exists.
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        // 2. Validate the password is correct.
        if (!_securePasswordProvider.Verify(query.Password, user.PasswordHash, query.Email))
            return Errors.Authentication.InvalidCredentials;
        // 3. Create JWT token.
        var accessToken = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        // 4. Store the refresh token in the database.
        await _userRepository.StoreRefreshToken(user.Id!.Value.ToString(), refreshToken);

        return new AuthenticationResult(
            user,
            new TokenResult(accessToken, refreshToken)
        );
    }
}