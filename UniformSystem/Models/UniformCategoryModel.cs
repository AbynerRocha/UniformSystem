using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class UniformCategory
{
    public int Id { get; init; }
    public required string Name { get; init; }
    
}