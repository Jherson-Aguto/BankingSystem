using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CSBank.Application.Interfaces.IRepositories;
using CSBank.Application.Models;
using CSBank.Application.Models.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CSBank.Infrastructure.Utils;

public class CreateToken(
    IOptions<JwtOptions> options)
    : ICreateTokenService
{
    public string CreateAccessTokenAsync(UserClaimsDto userClaims)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userClaims.UserId.ToString()),
            new Claim(ClaimTypes.Email, userClaims.Email),
            new Claim(ClaimTypes.Role, userClaims.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(options.Value.Secret)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                options.Value.ExpiryInMinutes
            ),
            signingCredentials: creds
        );

        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(token);
    }

    public string CreateRefreshTokenAsync()
    {
        var bytes = RandomNumberGenerator.GetBytes(64);

        return Convert.ToBase64String(bytes);
    }
}