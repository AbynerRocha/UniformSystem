using Microsoft.AspNetCore.Mvc;
using UniformSystem.Features.Inventory.DTOs;
using UniformSystem.Features.Inventory.Services;

namespace UniformSystem.Features.Inventory.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class InventoryController(IInventoryService inventoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FilterInventoryDto filter)
    {
        var data = await inventoryService.GetAllAsync(filter);
        return Ok(data);
    }
}