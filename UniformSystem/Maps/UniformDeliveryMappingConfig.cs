using Mapster;
using UniformSystem.DTOs.Response;
using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs;

namespace UniformSystem.Maps;

public static class UniformDeliveryMappingConfig
{
    public static void RegisterMapping()
    {
        TypeAdapterConfig<UniformDelivered, UniformDeliveryDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DeliveredAt, src => src.DeliveredAt)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Uniform, src => src.Uniform)
            .Map(dest => dest.Employee,
                src => src.ToEmployee == null ? null : new RelatedItemDTO(src.ToEmployee.Id, src.ToEmployee.Name))
            .Map(dest => dest.DeliveredBy,
                src => src.DeliveredBy == null ? null : new RelatedItemDTO(src.DeliveredBy.Id, src.DeliveredBy.Name));
    }
}