using UniformSystem.Constants;
using UniformSystem.Exceptions;

namespace UniformSystem.Features.Inventory.DTOs;

public class UpdateInventoryDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int UpdatedById { get; set; }
    public DateTime UpdatedOn { get; set; }
    
    public static void Validator(UpdateInventoryDto data)
    {
        if (data.Id <= 0)
            throw new InvalidParamException("Este uniforme é inválido.", ExceptionsTargets.Global);
        if (data.UpdatedById <= 0)
            throw new InvalidParamException("Usuário inválido.", ExceptionsTargets.Global);
    }
}