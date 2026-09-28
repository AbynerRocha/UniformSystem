namespace UniformSystem.Entities;

public class Permission
{
    public int Id { get; init; }
    public required string Name { get; init; }
    
    public ICollection<User> Users { get; init; } = new List<User>();
}