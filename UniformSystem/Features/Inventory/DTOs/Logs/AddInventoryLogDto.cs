using UniformSystem.Constants;
using UniformSystem.Exceptions;

namespace UniformSystem.Features.Inventory.DTOs.Logs;

public class AddInventoryLogDto
{
    public int UniformId { get; init; }
    public int Amount { get; init; }
    public int UpdatedById { get; init; }
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
}