using Backend.Application.Common.Interfaces.Authentication;
using Backend.Infrastructure.Authentication.Common;
using Microsoft.AspNetCore.Identity;

namespace Backend.Infrastructure.Authentication;

public class SecurePasswordProvider : ISecurePasswordProvider
{
    private readonly PasswordHasher<object> _passwordHasher;

    public SecurePasswordProvider()
    {
        _passwordHasher = new PasswordHasher<object>();
    }

    public bool Verify(string password, string hashedPassword, string email)
    {
        var credentials = new Credentials(
            email,
            password
        );
        var result = _passwordHasher.VerifyHashedPassword(credentials, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }

    public string Encrypt(string password, string email)
    {
        var credentials = new Credentials(
            email,
            password
        );

        return _passwordHasher.HashPassword(credentials, password);
    }
}