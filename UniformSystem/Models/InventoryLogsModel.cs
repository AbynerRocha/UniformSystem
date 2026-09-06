using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class InventoryLogs
{
    public int Id { get; init; }
    public int UniformId { get; init; }
    public int UpdatedById { get; init; }
    public DateTime LogDate { get; init; }
    public int Amount { get; init; }

    public required Uniform Uniform { get; init; }
    public required User UpdatedBy { get; init; }
}