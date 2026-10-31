using System.Security.Authentication;
using UniformSystem.Data;
using UniformSystem.Entities;
using UniformSystem.Exceptions;
using UniformSystem.Features.Auth.DTOs;
using UniformSystem.Features.Jwt.Services;
using UniformSystem.Features.Tokens.Services;
using UniformSystem.Features.Users.Repositories;
using UniformSystem.Security;

namespace UniformSystem.Features.Auth.Services;

public class AuthService(
    IUserRepository userRepository,
    JwtService jwt,
    PasswordHasher passwordHasher,
    ITokenService tokenService,
    IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<List<string>> LoginAsync(LoginRequestDTO dto)
    {
        LoginRequestDTO.Validator(dto);

        var user = await userRepository.GetUserAsync(new Email(dto.Email));

        if (user is null)
            throw new InvalidCredentialException();

        var matchPassword = passwordHasher.Verify(dto.Password, user.PasswordHash);

        if (!matchPassword)
            throw new InvalidCredentialsException();

        var accessToken = jwt.GenerateAccessToken(user.Id, user.Permissions);
        var refreshToken = jwt.GenerateRefreshToken(user.Id);

        await unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await tokenService.AddTokenAsync(accessToken, TokenType.AccessToken);
            await tokenService.AddTokenAsync(refreshToken, TokenType.RefreshToken);
        });

        return [accessToken, refreshToken];
    }
}