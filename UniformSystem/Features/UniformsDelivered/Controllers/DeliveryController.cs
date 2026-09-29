using Microsoft.AspNetCore.Mvc;
using UniformSystem.Features.UniformsDelivered.DTOs;
using UniformSystem.Features.UniformsDelivered.Services;

namespace UniformSystem.Features.UniformsDelivered.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DeliveryController(IUniformDeliveredService uniformDeliveredService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await uniformDeliveredService.GetUniformDelivery(id);
        
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterDeliveredUniformsDto filters)
    {
        var response = await uniformDeliveredService.GetUniformDeliveries(filters);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeliveryUniformRequestDto request)
    {
        await uniformDeliveredService.SaveDelivery(request);

        return Created();
    }
}