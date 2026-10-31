using UniformSystem.Entities;
using UniformSystem.Exceptions;
using UniformSystem.Exceptions.Token;
using UniformSystem.Features.Tokens.Repositories;

namespace UniformSystem.Features.Tokens.Services;

public class TokenService(ITokenRepository tokenRepository) : ITokenService
{
    public async Task<Token> GetTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new NullParamException("The token cannot be null", "system");

        var data = await tokenRepository.GetTokenAsync(token);

        if (data == null)
            throw new InvalidTokenException();

        return data.IsRevoked ? throw new ExpiredTokenException() : data;
    }

    public async Task RevokeTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new NullParamException("The token cannot be null", "system");

        var data = await tokenRepository.GetTokenAsync(token);

        if (data == null)
            throw new InvalidTokenException();

        if (data.IsRevoked)
            throw new ExpiredTokenException();

        await tokenRepository.RevokeTokenAsync(token);
    }

    public async Task AddTokenAsync(string token, TokenType type)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new NullParamException("The token cannot be null", "system");

        var data = await tokenRepository.GetTokenAsync(token);

        if (data != null)
            throw new EntityAlreadyExistsException("EXPIRED_TOKEN", token, "system");

        await tokenRepository.AddTokenAsync(new Token
        {
            Value = token,
            Type = type,
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false
        });
    }
}