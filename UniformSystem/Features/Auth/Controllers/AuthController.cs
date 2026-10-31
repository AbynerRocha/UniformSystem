using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniformSystem.Features.Auth.DTOs;
using UniformSystem.Features.Auth.Services;

namespace UniformSystem.Features.Auth.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController(IAuthService authService, IWebHostEnvironment environment) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
    {
        var tokens = await authService.LoginAsync(dto);
        
        var accessToken = tokens.ElementAt(0);
        var refreshToken = tokens.ElementAt(1);
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(7),
            Path = "/api/auth/refresh"
        };
        
        Response.Cookies.Append("us-refresh-token", refreshToken, cookieOptions);
        return Ok(accessToken);
    }

    [Authorize]
    [HttpGet("debug-token")]
    public IActionResult DebugToken()
    {
        if (!environment.IsDevelopment())
            return NotFound();

        return Ok(new
        {
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
            AuthenticationType = User.Identity?.AuthenticationType,
            Claims = User.Claims.Select(claim => new { claim.Type, claim.Value })
        });
    }
}
