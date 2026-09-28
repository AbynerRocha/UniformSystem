using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UniformSystem.Security.Permissions;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var hasPermission = context.User.HasClaim(c =>
            c.Type == "permission" &&
            string.Equals(c.Value, requirement.Permission, StringComparison.InvariantCultureIgnoreCase));

        if (hasPermission)
            context.Succeed(requirement);
        
        return Task.CompletedTask;
    }
}