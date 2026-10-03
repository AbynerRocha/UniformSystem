using UniformSystem.Constants;
using UniformSystem.Exceptions;
using UniformSystem.Exceptions.Inventory;
using UniformSystem.Exceptions.Uniform;
using UniformSystem.Features.Inventory.DTOs;
using UniformSystem.Features.Inventory.DTOs.Logs;
using UniformSystem.Features.Inventory.Repositories;
using UniformSystem.Features.Uniforms.Services;

namespace UniformSystem.Features.Inventory.Services;

public class InventoryService(IInventoryRepository inventoryRepository, IInventoryLogsService logsService) : IInventoryService
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
        await logsService.RegisterLogAsync(new AddInventoryLogDto
        {
            UniformId = data.UniformId,
            Amount = data.Amount,
            UpdatedAt = DateTime.UtcNow,
            UpdatedById = data.UpdatedById
        });
    }
    
    public async Task<int> GetStockFromUniformAsync(int uniformId)
    {
        if (uniformId <= 0)
            throw new InvalidParamException("Uniforme inválido", ExceptionsTargets.Global);
        
        var stock = await inventoryRepository.GetStockFromUniformAsync(uniformId);

        return stock ?? throw new InventoryItemNotFoundException("Este item não esta registrado", ExceptionsTargets.Global);
    }

    public async Task<int> GetStockFromUniformAsync(string uniformReference)
    {
        if(string.IsNullOrWhiteSpace(uniformReference))
            throw new InvalidParamException("Referência inválido", ExceptionsTargets.Global);
        
        var stock = await inventoryRepository.GetStockFromUniformAsync(uniformReference);

        return stock ?? throw new InventoryItemNotFoundException("Este item não esta registrado", ExceptionsTargets.Global);
    }

    public async Task<bool> TryDecreaseStockFromUniformAsync(int uniformId, int amount)
    {
        if (amount <= 0)
            throw new InvalidParamException("Quantidade inválida", ExceptionsTargets.Global);
        
        return await inventoryRepository.TryDecreaseStockFromUniformAsync(uniformId, amount);
    }

    public async Task UpdateStockAsync(int userId, int uniformId, int amount)
    {
        if (uniformId <= 0)
            throw new InvalidParamException("Uniforme inválido.", ExceptionsTargets.Global);
        
        var stock = await GetStockFromUniformAsync(uniformId);
        var stockUpdated = stock-amount;
        
        await inventoryRepository.UpdateStockAsync(uniformId, stockUpdated);
        await logsService.RegisterLogAsync(new AddInventoryLogDto
        {
            UniformId = uniformId,
            Amount = stockUpdated,
            UpdatedAt = DateTime.UtcNow,
            UpdatedById = userId
        });
    }
}