using UniformSystem.Constants;
using UniformSystem.Exceptions;
using UniformSystem.Exceptions.Inventory;
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
    
    public async Task<int> GetStockFromUniform(int uniformId)
    {
        if (uniformId <= 0)
            throw new InvalidParamException("Uniforme inválido", ExceptionsTargets.Global);
        
        var stock = await inventoryRepository.GetStockFromUniform(uniformId);

        return stock ?? throw new InventoryItemNotFoundException("Este item não esta registrado", ExceptionsTargets.Global);
    }

    public async Task<int> GetStockFromUniform(string uniformReference)
    {
        if(string.IsNullOrWhiteSpace(uniformReference))
            throw new InvalidParamException("Referência inválido", ExceptionsTargets.Global);
        
        var stock = await inventoryRepository.GetStockFromUniform(uniformReference);

        return stock ?? throw new InventoryItemNotFoundException("Este item não esta registrado", ExceptionsTargets.Global);
    }
}