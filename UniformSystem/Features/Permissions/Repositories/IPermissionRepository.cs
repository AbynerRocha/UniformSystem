using UniformSystem.Entities;

namespace UniformSystem.Features.Permissions.Repositories;

public interface IPermissionRepository
{
    public Task<Permission?> FindPermissionAsync(string permission);
    public Task<List<Permission>> FindPermissionAsync(List<string> permissions);
}