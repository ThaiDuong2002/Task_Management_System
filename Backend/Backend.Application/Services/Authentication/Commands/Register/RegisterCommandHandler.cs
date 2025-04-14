using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Authentication.Common;
using Backend.Domain.Common.Errors;
using Backend.Domain.Models.UserModel;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ISecurePasswordProvider _securePasswordProvider;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository,
        ISecurePasswordProvider securePasswordProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _securePasswordProvider = securePasswordProvider;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;
        
        if (await _userRepository.GetUserByUserName(command.UserName) is not null)
            return Errors.User.DuplicateUserName;

        // Create user (generate unique id)
        var user = new User
        {
            Id = null,
            UserName = command.UserName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = _securePasswordProvider.Encrypt(command.Password, command.Email),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var result = await _userRepository.Create(user);

        if (result is null)
            return Errors.User.FailedToRegister;

        user.Id = result;

        var accessToken = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        return new AuthenticationResult(
            user,
            new TokenResult(accessToken, refreshToken)
        );
    }
}