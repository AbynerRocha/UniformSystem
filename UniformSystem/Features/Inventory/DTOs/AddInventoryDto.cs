using UniformSystem.Constants;
using UniformSystem.Exceptions;

namespace UniformSystem.Features.Inventory.DTOs;

public class AddInventoryDto
{
    public int UniformId { get; set; }
    public int Amount { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public static void Validator(AddInventoryDto data)
    {
        if (data.UniformId <= 0)
            throw new InvalidParamException("Este uniforme é inválido.", ExceptionsTargets.Global);
        if (data.UpdatedById <= 0)
            throw new InvalidParamException("Usuário inválido.", ExceptionsTargets.Global);
    }
}