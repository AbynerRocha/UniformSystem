using UniformSystem.DTOs.Response;

namespace UniformSystem.Features.UniformsDelivered.DTOs;

public class UniformDeliveryDto
{
    public int Id { get; init; }
    public DateTime DeliveredAt { get; init; }
    public int Amount { get; init; }
    
    public UniformSummaryDto? Uniform { get; init; }
    public RelatedItemDTO? Employee { get; init; }
    public RelatedItemDTO? DeliveredBy { get; init; }
}