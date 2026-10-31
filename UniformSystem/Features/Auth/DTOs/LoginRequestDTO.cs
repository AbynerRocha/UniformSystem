using UniformSystem.Constants;
using UniformSystem.Exceptions;

namespace UniformSystem.Features.Auth.DTOs;

public class LoginRequestDTO
{
    public required string Email { get; init; }
    public required string Password { get; init; }

    public static void Validator(LoginRequestDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new NullParamException("O email não pode estar vazio.", ExceptionsTargets.Email);
        if(string.IsNullOrWhiteSpace(dto.Password))
            throw new NullParamException("A senha não pode estar vazia.", ExceptionsTargets.Password);
        
        if(!Entities.Email.ValidateEmail(dto.Email)) 
            throw new InvalidParamException("Este email não é valido.",  ExceptionsTargets.Email);
    }
}