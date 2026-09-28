using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Entities;

namespace UniformSystem.Features.Permissions.Repositories;

public class PermissionRepository(AppDatabaseContext dbContext) : IPermissionRepository
{
    public async Task<Permission?> FindPermissionAsync(string permission)
    {
        return await dbContext.Permissions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => string.Equals(p.Name, permission, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<List<Permission>> FindPermissionAsync(List<string> permissions)
    {
        return await dbContext.Permissions
            .AsNoTracking()
            .Where(p => permissions.Contains(p.Name))
            .ToListAsync();
    }
}