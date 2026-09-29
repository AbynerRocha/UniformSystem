using UniformSystem.Features.Inventory.DTOs;
using UniformSystem.Features.Inventory.Repositories;

namespace UniformSystem.Features.Inventory.Services;

public class InventoryService(IInventoryRepository inventoryRepository) : IInventoryService
{
    public async Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter)
    {
        return await inventoryRepository.GetAllAsync(filter);
    }

    public async Task AddAsync(AddInventoryDto data)
    {
        AddInventoryDto.Validator(data);
        
        await inventoryRepository.AddAsync(data);
    }
    
    public async Task UpdateAsync(UpdateInventoryDto data)
    {
        UpdateInventoryDto.Validator(data);

        await inventoryRepository.UpdateAsync(data);
    }
}