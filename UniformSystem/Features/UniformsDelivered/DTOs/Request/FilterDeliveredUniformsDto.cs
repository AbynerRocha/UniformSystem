using Microsoft.AspNetCore.Mvc;

namespace UniformSystem.Features.UniformsDelivered.DTOs.Request;

public class FilterDeliveredUniformsDto
{
    public string? Name { get; set; }
    [FromQuery(Name = "ref")]
    public string? Reference { get; set; }
    public string? Size { get; set; }
    public char? Sex { get; init; }

    [FromQuery(Name = "cat")]
    public int? UniformCategoryId { get; set; }
    
    [FromQuery(Name = "p")]
    public int Page { get; set; } = 1;
    [FromQuery(Name = "psize")]
    public int PageSize { get; set; } = 20;
}