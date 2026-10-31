using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Entities;

namespace UniformSystem.Features.Permissions.Repositories;

public class PermissionRepository(AppDatabaseContext dbContext) : IPermissionRepository
{
    public async Task<Permission?> FindPermissionAsync(string permission)
    {
        var normalized = permission.Trim().ToLowerInvariant();

        return await dbContext.Permissions
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Name == normalized);
    }

    public async Task<List<Permission>> FindPermissionAsync(List<string> permissions)
    {
        var normalizedPermissions = permissions
            .Select(permission => permission.Trim().ToLowerInvariant())
            .Distinct()
            .ToArray();

        // Keep these entities tracked: they are attached to a new User below.
        // AsNoTracking would leave them detached, and Users.AddAsync could mark
        // them as new rows and attempt to insert duplicate permissions.
        return await dbContext.Permissions
            .Where(permission => normalizedPermissions.Contains(permission.Name))
            .ToListAsync();
    }
}

