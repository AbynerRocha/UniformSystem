using UniformSystem.Entities;

namespace UniformSystem.Features.Tokens.Services;

public interface ITokenService
{
    public Task<Token> GetTokenAsync(string token);
    public Task RevokeTokenAsync(string token);
    public Task AddTokenAsync(string token, TokenType type);
}