using UniformSystem.Features.Inventory.DTOs.Logs;

namespace UniformSystem.Features.Inventory.Repositories;

public interface IInventoryLogsRepository
{
    public Task RegisterLogAsync(AddInventoryLogDto data);
}