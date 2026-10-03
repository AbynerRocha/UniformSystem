using UniformSystem.Features.Inventory.DTOs.Logs;

namespace UniformSystem.Features.Inventory.Services;

public interface IInventoryLogsService
{
    public Task RegisterLogAsync(AddInventoryLogDto dto);
}