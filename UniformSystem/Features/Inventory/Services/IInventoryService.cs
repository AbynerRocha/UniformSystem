using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Features.Inventory.Services;

public interface IInventoryService
{
    public Task UpdateAsync(UpdateInventoryDto data);
    public Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter);
    public Task AddAsync(AddInventoryDto data);
}