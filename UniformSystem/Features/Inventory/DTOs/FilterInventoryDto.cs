using Microsoft.AspNetCore.Mvc;

namespace UniformSystem.Features.Inventory.DTOs;

public class FilterInventoryDto
{
    public string? Name { get; set; } = string.Empty;
    [FromQuery(Name = "ref")]
    public string? Reference { get; set; } = string.Empty;
    
    [FromQuery(Name = "p")]
    public int Page { get; set; }
    [FromQuery(Name = "psize")]
    public int PageSize { get; set; }
}