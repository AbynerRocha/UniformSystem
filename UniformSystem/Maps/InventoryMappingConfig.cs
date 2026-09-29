using Mapster;
using UniformSystem.DTOs.Response;
using UniformSystem.Entities;
using UniformSystem.Features.Inventory.DTOs;

namespace UniformSystem.Maps;

public static class InventoryMappingConfig
{
    public static void RegisterMap()
    {
        TypeAdapterConfig<Inventory, InventoryDto>
            .NewConfig()
            .Map(dest => dest.Uniform, src => src.Uniform)
            .Map(dest => dest.UpdatedBy, src => new RelatedItemDTO(src.UpdatedBy!.Id, src.UpdatedBy.Name));
    }
}