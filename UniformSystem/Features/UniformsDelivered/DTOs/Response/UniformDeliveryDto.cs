namespace UniformSystem.Features.UniformsDelivered.DTOs.Response;

public record RelatedItemDto(int Id, string Name);
public record UniformSummaryDto(int Id, string Name, string Reference, RelatedItemDto? Category,  string Size, char Sex);

public class UniformDeliveryDto
{
    public int Id { get; init; }
    public DateTime DeliveredAt { get; init; }
    public int Amount { get; init; }
    
    public UniformSummaryDto? Uniform { get; init; }
    public RelatedItemDto? Employee { get; init; }
    public RelatedItemDto? DeliveredBy { get; init; }
}