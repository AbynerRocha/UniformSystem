using UniformSystem.Constants;
using UniformSystem.Exceptions;

namespace UniformSystem.Features.Inventory.DTOs;

public class UpdateInventoryDto
{
    public int UniformId { get; init; }
    public int? Amount { get; init; }
    public int? MinAmount { get; init; }
    public int UpdatedById { get; init; }
    public DateTime UpdatedOn { get; init; }

    public static void Validator(UpdateInventoryDto data)
    {
        if (data.UniformId <= 0)
            throw new InvalidParamException("Este uniforme é inválido.", ExceptionsTargets.Global);
        if (data.UpdatedById <= 0)
            throw new InvalidParamException("Usuário inválido.", ExceptionsTargets.Global);
        
        if (data.Amount is null && data.MinAmount is null)
            throw new InvalidParamException("Informe a quantidade ou o nível mínimo.", ExceptionsTargets.Global);

        if (data.Amount < 0 || data.MinAmount < 0)
            throw new InvalidParamException("Os valores não podem ser negativos.",  ExceptionsTargets.Global);
    }
}