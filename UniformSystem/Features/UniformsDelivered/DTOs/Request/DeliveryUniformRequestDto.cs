using UniformSystem.Constants;
using UniformSystem.Exceptions;
using UniformSystem.Features.Uniforms.DTOs;

namespace UniformSystem.Features.UniformsDelivered.DTOs.Request;

public class DeliveryUniformRequestDto
{
    public required int DeliveredById  { get; set; }
    public required int DeliveredToEmployeeId  { get; set; }
    public required int UniformId  { get; set; }
    public required int Amount { get; set; }
    
    public DateTime DeliveredAt { get; set; } = DateTime.UtcNow;

    public static void Validator(DeliveryUniformRequestDto request)
    {
        if (request.DeliveredById <= 0)
            throw new InvalidParamException("Id de usuário inválido.", ExceptionsTargets.Global);
        if (request.DeliveredToEmployeeId <= 0)
            throw new InvalidParamException("Funcionário inválido.", ExceptionsTargets.Employee);
        if (request.UniformId <= 0)
            throw new InvalidParamException("Uniforme inválido.", ExceptionsTargets.Uniform);
        if (request.Amount <= 0)
            throw new InvalidParamException("A quantia tem de ser maior que 0.", ExceptionsTargets.Amount);
    }
}