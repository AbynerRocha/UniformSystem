using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs.Request;
using UniformSystem.Features.UniformsDelivered.DTOs.Response;

namespace UniformSystem.Features.UniformsDelivered.Repositories;

public interface IUniformDeliveredRepository
{
    public Task SaveDeliveryAsync(DeliveryUniformRequestDto delivery);
    public Task<DeliveryUniformDto?> GetDeliveryAsync(int id);
    public Task<List<DeliveryUniformDto>> GetAllDeliveriesAsync();
    public Task<List<DeliveryUniformDto>> GetAllDeliveriesByUserIdAsync(int userId);
    public Task<List<DeliveryUniformDto>> GetAllDeliveriesToEmployeeIdAsync(int employeeId);
}