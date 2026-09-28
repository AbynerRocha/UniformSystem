using Microsoft.AspNetCore.Mvc;
using UniformSystem.Entities;
using UniformSystem.Features.UniformsDelivered.DTOs.Request;
using UniformSystem.Features.UniformsDelivered.Repositories;

namespace UniformSystem.Features.UniformsDelivered.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DeliveryController(IUniformDeliveredRepository  repository) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await repository.GetDeliveryAsync(id);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeliveryUniformRequestDto request)
    {
        DeliveryUniformRequestDto.Validator(request);
        
        await repository.SaveDeliveryAsync(request);

        return Created();
    }
}