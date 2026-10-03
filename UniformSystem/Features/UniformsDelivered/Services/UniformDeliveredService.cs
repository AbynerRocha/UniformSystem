using UniformSystem.Data;
using UniformSystem.Exceptions.Inventory;
using UniformSystem.Exceptions.Users;
using UniformSystem.Features.Inventory.DTOs.Logs;
using UniformSystem.Features.Inventory.Repositories;
using UniformSystem.Features.Inventory.Services;
using UniformSystem.Features.UniformsDelivered.DTOs;
using UniformSystem.Features.UniformsDelivered.Repositories;

namespace UniformSystem.Features.UniformsDelivered.Services;

public class UniformDeliveredService(
    IUniformDeliveredRepository repository,
    IInventoryService inventoryService,
    IInventoryLogsService inventoryLogsService,
    IUnitOfWork unitOfWork) : IUniformDeliveredService
{
    public async Task<UniformDeliveryDto> GetUniformDelivery(int id)
    {
        if (id <= 0)
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

        await unitOfWork.ExecuteTransactionAsync(async () =>
        {
            var stockDecreased = await inventoryService.TryDecreaseStockFromUniformAsync(dto.UniformId, dto.Amount);

            if (!stockDecreased)
                throw new InsufficientStockException();
            
            await repository.SaveDeliveryAsync(dto);
            await inventoryLogsService.RegisterLogAsync(new AddInventoryLogDto
            {
                UniformId = dto.UniformId,
                UpdatedAt = DateTime.UtcNow,
                Amount = dto.Amount,
                UpdatedById = dto.DeliveredById
            });
        });
    }
}