using Mapster;
using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs.Response;

namespace UniformSystem.Maps;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Uniform, UniformSummaryDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.Sex, src => src.Sex)
            .Map(dest => dest.Category,
                src => src.UniformCategory == null
                    ? null
                    : new RelatedItemDto(
                        src.UniformCategory.Id,
                        src.UniformCategory.Name));

        TypeAdapterConfig<UniformDelivered, DeliveryUniformDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.DeliveredAt, src => src.DeliveredAt)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Uniform, src => src.Uniform)
            .Map(dest => dest.Employee,
                src => src.ToEmployee == null ? null : new RelatedItemDto(src.ToEmployee.Id, src.ToEmployee.Name))
            .Map(dest => dest.DeliveredBy,
                src => src.DeliveredBy == null ? null : new RelatedItemDto(src.DeliveredBy.Id, src.DeliveredBy.Name));
    }
}
