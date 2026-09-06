using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class User
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }

    public ICollection<UniformDelivered> UniformDelivered { get; init; } = new List<UniformDelivered>();
    public ICollection<InventoryLogs> InventoryLogs { get; init; } = new List<InventoryLogs>();
    public ICollection<Inventory> Inventories { get; init; } = new List<Inventory>();
    
}