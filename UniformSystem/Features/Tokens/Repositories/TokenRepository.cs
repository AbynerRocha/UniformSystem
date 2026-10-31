
using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Entities;

namespace UniformSystem.Features.Tokens.Repositories;

public class TokenRepository(AppDatabaseContext dbContext) : ITokenRepository
{
    public async Task<Token?> GetTokenAsync(string token) => await dbContext.Tokens
        .AsNoTracking()
        .FirstOrDefaultAsync(i => i.Value == token);

    public async Task RevokeTokenAsync(string token)
    {
        await dbContext.Tokens
            .Where(u => u.Value == token)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsRevoked, true));
    }

    public async Task AddTokenAsync(Token token)
    {
        await dbContext.Tokens.AddAsync(token);
        await dbContext.SaveChangesAsync();
    }
}