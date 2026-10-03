using UniformSystem.DTOs.Response;

namespace UniformSystem.Features.Inventory.DTOs;

public class InventoryDto
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int MinAmount { get; set; }
    public UniformSummaryDto? Uniform { get; set; }
    public RelatedItemDTO? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}