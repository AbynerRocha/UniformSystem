using UniformSystem.Exceptions.Users;
using UniformSystem.Features.UniformsDelivered.DTOs;
using UniformSystem.Features.UniformsDelivered.Repositories;

namespace UniformSystem.Features.UniformsDelivered.Services;

public class UniformDeliveredService(IUniformDeliveredRepository repository) : IUniformDeliveredService
{
    public async Task<UniformDeliveryDto> GetUniformDelivery(int id)
    {
        if(id <= 0) 
            throw new InvalidOperationException("Não foi possível encontrar esta entrega.");

        var delivery = await repository.GetDeliveryAsync(id);
        
        return delivery ?? throw new UniformDeliveryNotFoundException();
    }

    public async Task<IEnumerable<UniformDeliveryDto>> GetUniformDeliveries(FilterDeliveredUniformsDto filter)
    {
        return await repository.GetAllDeliveriesAsync(filter);
    }

    public async Task SaveDelivery(DeliveryUniformRequestDto dto)
    {
        DeliveryUniformRequestDto.Validator(dto);
        
        await repository.SaveDeliveryAsync(dto);
    }
}