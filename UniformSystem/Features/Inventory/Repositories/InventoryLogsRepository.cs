using UniformSystem.Data;
using UniformSystem.Entities;
using UniformSystem.Features.Inventory.DTOs.Logs;

namespace UniformSystem.Features.Inventory.Repositories;

public class InventoryLogsRepository(AppDatabaseContext dbContext): IInventoryLogsRepository
{
    public async Task RegisterLogAsync(AddInventoryLogDto data)
    {
        await dbContext.InventoryLogs.AddAsync(new InventoryLogs
        {
            Amount = data.Amount,
            UniformId = data.UniformId,
            LogDate = data.UpdatedAt,
            UpdatedById = data.UpdatedById
        });
        await dbContext.SaveChangesAsync();
    }
}