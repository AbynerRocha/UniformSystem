using Microsoft.AspNetCore.Authorization;

namespace UniformSystem.Security.Permissions;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}