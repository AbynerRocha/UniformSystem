using UniformSystem.Features.UniformsDelivered.DTOs.Request;
using UniformSystem.Features.UniformsDelivered.DTOs.Response;

namespace UniformSystem.Features.UniformsDelivered.Services;

public interface IUniformDeliveredService
{
    public Task<UniformDeliveryDto> GetUniformDelivery(int id);
    public Task<IEnumerable<UniformDeliveryDto>> GetUniformDeliveries(FilterDeliveredUniformsDto filter);
    public Task SaveDelivery(DeliveryUniformRequestDto dto);
    
}