namespace UniformSystem.Exceptions;

public abstract class EntityException(string message, string target) : Exception(message)
{
    public string Error { get; } = message;
    public string Target { get; } = target;
}