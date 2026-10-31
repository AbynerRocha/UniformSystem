using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UniformSystem.Entities;

namespace UniformSystem.Features.Jwt.Services;

public class JwtService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtService(IConfiguration configuration)
    {
        _secretKey = configuration["JWT:Key"] ?? throw new InvalidOperationException("Missing JWT SecretKey");
        _issuer = configuration["JWT:Issuer"] ?? throw new InvalidOperationException("Missing JWT Issuer");
        _audience = configuration["JWT:Audience"] ?? throw new InvalidOperationException("Missing JWT Audience");
    }

    public string GenerateRefreshToken(int userId, DateTime? expiration = null)
    {
        var validUntil = expiration ?? DateTime.UtcNow.AddDays(7);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var token = GenerateToken(claims, validUntil);
        
        return token;
    }

    public string GenerateAccessToken(int userId, IEnumerable<Permission> permissions, DateTime? expiration = null)
    {
        var validUntil = expiration ?? DateTime.UtcNow.AddMinutes(30);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        claims.AddRange(permissions.Select(permission => new Claim("permission", permission.Name)));

        var token = GenerateToken(claims, validUntil);
        
        return token;
    }

    private string GenerateToken(List<Claim> claims, DateTime expiration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}