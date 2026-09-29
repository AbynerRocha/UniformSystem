using Mapster;
using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs;

namespace UniformSystem.Features.UniformsDelivered.Repositories;

public class UniformDeliveredRepository(AppDatabaseContext dbContext) : IUniformDeliveredRepository
{
    public async Task SaveDeliveryAsync(DeliveryUniformRequestDto delivery)
    {
        await dbContext.UniformDelivered.AddAsync(new UniformDelivered
        {
            Amount = delivery.Amount,
            DeliveredById = delivery.DeliveredById,
            UniformId = delivery.UniformId,
            DeliveredAt = delivery.DeliveredAt,
            ToEmployeeId = delivery.DeliveredToEmployeeId
        });
        await dbContext.SaveChangesAsync();
    }

    public async Task<UniformDeliveryDto?> GetDeliveryAsync(int id)
    {
        return await dbContext.UniformDelivered
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectToType<UniformDeliveryDto>()
            .FirstOrDefaultAsync();
    }

    public async Task<List<UniformDeliveryDto>> GetAllDeliveriesAsync(FilterDeliveredUniformsDto filter)
    {
        var query = dbContext.UniformDelivered
            .AsNoTracking()
            .AsQueryable();

        if (filter.Sex.HasValue)
            query = query.Where(d =>
                d.Uniform != null && d.Uniform.Sex == char.ToUpperInvariant(filter.Sex.Value));

        if (!string.IsNullOrWhiteSpace(filter.Size))
        {
            var size = filter.Size.Trim().ToUpperInvariant();
            query = query.Where(d => d.Uniform != null && d.Uniform.Size == size);
        }

        if (filter.UniformCategoryId.HasValue)
            query = query.Where(d =>
                d.Uniform != null && d.Uniform.UniformCategoryId == filter.UniformCategoryId.Value);

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            var namePattern = $"%{filter.Name.Trim()}%";
            query = query.Where(d =>
                d.Uniform != null && EF.Functions.ILike(d.Uniform.Name, namePattern));
        }

        if (!string.IsNullOrWhiteSpace(filter.Reference))
        {
            var referencePattern = $"%{filter.Reference.Trim()}%";
            query = query.Where(d =>
                d.Uniform != null && EF.Functions.ILike(d.Uniform.Reference, referencePattern));
        }

        var page = Math.Max(filter.Page, 1);
        var pageSize = Math.Clamp(filter.PageSize, 1, 100);

        return await query
            .OrderByDescending(d => d.DeliveredAt)
            .ThenByDescending(d => d.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectToType<UniformDeliveryDto>()
            .ToListAsync();
    }

    public Task<List<UniformDeliveryDto>> GetAllDeliveriesByUserIdAsync(int userId, FilterDeliveredUniformsDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<List<UniformDeliveryDto>> GetAllDeliveriesToEmployeeIdAsync(int employeeId,
        FilterDeliveredUniformsDto filter)
    {
        throw new NotImplementedException();
    }
}
