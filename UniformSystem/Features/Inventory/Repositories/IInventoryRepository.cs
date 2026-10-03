using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Features.Inventory.Repositories;

public interface IInventoryRepository
{
    public Task AddAsync(AddInventoryDto data);
    public Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter);
    public Task UpdateAsync(UpdateInventoryDto data);
    
    public Task<int?> GetStockFromUniformAsync(int uniformId);
    public Task<int?> GetStockFromUniformAsync(string uniformReference);
    public Task<int> UpdateStockAsync(int uniformId, int amount);
    public Task<bool> TryDecreaseStockFromUniformAsync(int uniformId, int amount);
}