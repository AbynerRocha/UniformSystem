using Mapster;
using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Features.Inventory.Repositories;

public class InventoryRepository(AppDatabaseContext dbContext) : IInventoryRepository
{
    public async Task AddAsync(AddInventoryDto data)
    {
        await dbContext.Inventory.AddAsync(new Entities.Inventory
        {
            Amount = data.Amount,
            UniformId = data.UniformId,
            UpdatedById = data.UpdatedById,
            UpdatedAt = data.UpdatedAt
        });
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<InventoryDto>> GetAllAsync(FilterInventoryDto filter)
    {
        var query = dbContext.Inventory.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(i => EF.Functions.Like(i.Uniform!.Name, $"%{filter.Name}%"));
        if (!string.IsNullOrWhiteSpace(filter.Reference))
            query = query.Where(i => EF.Functions.Like(i.Uniform!.Reference, $"%{filter.Reference}%"));

        return await query
            .ProjectToType<InventoryDto>()
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
    }

    public async Task UpdateAsync(UpdateInventoryDto data)
    {
        dbContext.Update(data);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int?> GetStockFromUniform(int uniformId)
    {
        return await dbContext.Inventory
            .AsNoTracking()
            .Where(i => i.UniformId == uniformId)
            .Select(i => (int?)i.Amount)
            .FirstOrDefaultAsync();
    }

    public async Task<int?> GetStockFromUniform(string uniformReference)
    {
        return await dbContext.Inventory
            .AsNoTracking()
            .Where(i => i.Uniform!.Reference == uniformReference)
            .Select(i => (int?)i.Amount)
            .FirstOrDefaultAsync();
    }
}