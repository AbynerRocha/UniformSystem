using UniformSystem.Models;

namespace UniformSystem.Repositories.Interfaces;

public interface IUniformRepository
{
    public Task<IEnumerable<Uniform>> GetAllUniformsAsync();
    public Task<Uniform?> GetUniformByIdAsync(int id);
    public Task<Uniform?> GetUniformByRefAsync(string reference);
    
    public Task CreateUniformAsync(Uniform uniform);
    public void UpdateUniform(Uniform uniform);
    public void DeleteUniform(Uniform uniform);
}