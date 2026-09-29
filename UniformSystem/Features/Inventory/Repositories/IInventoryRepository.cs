using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Features.Inventory.Repositories;

public interface IInventoryRepository
{
    public Task AddAsync(AddInventoryDto data);
    public Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter);
    public Task UpdateAsync(UpdateInventoryDto data);
}