using UniformSystem.Features.Auth.DTOs;

namespace UniformSystem.Features.Auth.Services;

public interface IAuthService
{
    public Task<List<string>> LoginAsync(LoginRequestDTO dto);
}