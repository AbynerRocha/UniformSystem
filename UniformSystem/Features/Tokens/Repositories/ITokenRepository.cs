using UniformSystem.Entities;

namespace UniformSystem.Features.Tokens.Repositories;

public interface ITokenRepository
{
    public Task<Token?> GetTokenAsync(string token);
    public Task RevokeTokenAsync(string token);
    public Task AddTokenAsync(Token token);
}