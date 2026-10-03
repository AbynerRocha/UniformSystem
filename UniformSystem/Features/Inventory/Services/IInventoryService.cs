using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Features.Inventory.Services;

public interface IInventoryService
{
    public Task UpdateAsync(UpdateInventoryDto data);
    public Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter);
    public Task AddAsync(AddInventoryDto data);
    public Task<int> GetStockFromUniformAsync(int uniformId);
    public Task<int> GetStockFromUniformAsync(string uniformReference);
    public Task<bool> TryDecreaseStockFromUniformAsync(int uniformId, int amount);
}