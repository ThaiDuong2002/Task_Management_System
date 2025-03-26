using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Authentication.Common;
using Backend.Domain.Common.Errors;
using Backend.Domain.Entities;
using ErrorOr;

namespace Backend.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email,
        string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
            return Errors.User.DuplicateEmail;
        ;

        // Create user (generate unique id)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}