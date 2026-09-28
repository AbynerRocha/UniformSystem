using Mapster;
using Microsoft.EntityFrameworkCore;
using UniformSystem.Data;
using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs.Request;
using UniformSystem.Features.UniformsDelivered.DTOs.Response;

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

    public async Task<DeliveryUniformDto?> GetDeliveryAsync(int id)
    {
        return await dbContext.UniformDelivered
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectToType<DeliveryUniformDto>()
            .FirstOrDefaultAsync();
    }

    public Task<List<DeliveryUniformDto>> GetAllDeliveriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<DeliveryUniformDto>> GetAllDeliveriesByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<DeliveryUniformDto>> GetAllDeliveriesToEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }
}