using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Services;
using Backend.Domain.Models.UserModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString() ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var refreshToken = Convert.ToBase64String(randomNumber);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("refresh_token", refreshToken)
        };

        var securityToken = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public bool IsTokenExpired(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var expirationDate = jwtToken.ValidTo;
        return expirationDate < _dateTimeProvider.UtcNow;
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = _jwtSettings.Audience,
            ValidateIssuer = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            return null;

        return principal;
    }
}