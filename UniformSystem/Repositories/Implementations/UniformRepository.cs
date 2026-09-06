using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Models;
using UniformSystem.Repositories.Interfaces;

namespace UniformSystem.Repositories.Implementations;

public class UniformRepository(AppDatabaseContext dbContext) : IUniformRepository
{
    public async Task<IEnumerable<Uniform>> GetAllUniformsAsync()
    {
        return await dbContext.Uniforms.AsNoTracking().ToListAsync();
    }

    public async Task<Uniform?> GetUniformByIdAsync(int id)
    {
        return await dbContext.Uniforms.FindAsync(id);
    }

    public async Task<Uniform?> GetUniformByRefAsync(string reference)
    {
        return await dbContext.Uniforms
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                string.Equals(u.Reference, reference, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task CreateUniformAsync(Uniform uniform)
    {
        await dbContext.Uniforms.AddAsync(uniform);
    }

    public void UpdateUniform(Uniform uniform)
    {
        dbContext.Uniforms.Update(uniform);
    }

    public void DeleteUniform(Uniform uniform)
    {
        dbContext.Uniforms.Remove(uniform);
    }
}