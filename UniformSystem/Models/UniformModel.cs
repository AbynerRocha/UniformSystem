using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class Uniform
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Reference { get; init; }
    public required char Sex { get; init; }
    public required string Size { get; init; }
    public required int UniformCategoryId  { get; init; }
    
    public required UniformCategory UniformCategory { get; init; }
    public ICollection<Inventory> Inventories { get; init; } = new List<Inventory>();
    public ICollection<UniformDelivered> UniformDelivered { get; init; } = new List<UniformDelivered>();
    public ICollection<InventoryLogs>  InventoryLogs { get; init; } = new List<InventoryLogs>();
}