using UniformSystem.Features.Inventory.DTOs.Logs;
using UniformSystem.Features.Inventory.Repositories;

namespace UniformSystem.Features.Inventory.Services;

public class InventoryLogsService(IInventoryLogsRepository repository) : IInventoryLogsService
{
    public async Task RegisterLogAsync(AddInventoryLogDto dto)
    {
        await repository.RegisterLogAsync(dto);
    }
}