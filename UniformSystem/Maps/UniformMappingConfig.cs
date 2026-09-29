using Mapster;
using UniformSystem.DTOs.Response;
using UniformSystem.Entities;

namespace UniformSystem.Maps;

public static class UniformMappingConfig
{
    public static void RegisterMapping()
    {
        TypeAdapterConfig<Uniform, UniformSummaryDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Reference, src => src.Reference)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.Sex, src => src.Sex)
            .Map(dest => dest.Category,
                src => src.UniformCategory == null
                    ? null
                    : new RelatedItemDTO(
                        src.UniformCategory.Id,
                        src.UniformCategory.Name));
    }
}