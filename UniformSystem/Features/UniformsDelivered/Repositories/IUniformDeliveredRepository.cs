using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs.Request;
using UniformSystem.Features.UniformsDelivered.DTOs.Response;

namespace UniformSystem.Features.UniformsDelivered.Repositories;

public interface IUniformDeliveredRepository
{
    public Task SaveDeliveryAsync(DeliveryUniformRequestDto delivery);
    public Task<UniformDeliveryDto?> GetDeliveryAsync(int id);
    public Task<List<UniformDeliveryDto>> GetAllDeliveriesAsync(FilterDeliveredUniformsDto filter);
    public Task<List<UniformDeliveryDto>> GetAllDeliveriesByUserIdAsync(int userId,  FilterDeliveredUniformsDto filter);
    public Task<List<UniformDeliveryDto>> GetAllDeliveriesToEmployeeIdAsync(int employeeId, FilterDeliveredUniformsDto filter);
}