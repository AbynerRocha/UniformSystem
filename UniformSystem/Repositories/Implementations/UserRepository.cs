using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Models;
using UniformSystem.Repositories.Interfaces;

namespace UniformSystem.Repositories.Implementations;

public class UserRepository(AppDatabaseContext dbContext) : IUserRepository
{
    public async Task<User?> GetUserAsync(int id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetUserAsync(string email)
    {
        return await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => string.Equals(u.Email, email, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public void UpdateUser(User user)
    {
        dbContext.Users.Update(user);
    }

    public void DeleteUser(User user)
    {
        dbContext.Users.Remove(user);
    }
}