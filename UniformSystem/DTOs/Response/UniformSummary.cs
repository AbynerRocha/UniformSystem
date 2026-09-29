namespace UniformSystem.DTOs.Response;

public record UniformSummaryDto(int Id, string Name, string Reference, RelatedItemDTO? Category,  string Size, char Sex);