namespace UniformSystem.Exceptions;

public abstract class DomainException(string title, string message, string target) : Exception(message)
{
    public string Title { get; } = title;
    public string Target { get; } = target;
}