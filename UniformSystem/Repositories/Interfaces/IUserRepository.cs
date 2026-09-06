using UniformSystem.Models;

namespace UniformSystem.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetUserAsync(int id);
    public Task<User?> GetUserAsync(string email);
    
    public Task CreateUserAsync(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
}