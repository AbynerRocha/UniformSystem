namespace UniformSystem.Entities;

public enum TokenType
{
    RefreshToken = 0,
    AccessToken = 1
}

public class Token
{
    public int Id { get; init; }
    public required string Value { get; init; }
    public bool IsRevoked { get; init; }
    public TokenType Type { get; init; }
    public DateTime CreatedAt { get; init; }
}