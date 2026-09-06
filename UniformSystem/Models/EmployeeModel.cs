using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class Employee
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }

    public required ICollection<UniformDelivered> UniformDelivered { get; init; } = new List<UniformDelivered>();
}