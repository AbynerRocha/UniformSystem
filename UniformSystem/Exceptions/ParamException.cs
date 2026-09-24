namespace UniformSystem.Exceptions;

public class ParamException(string message, string target) : Exception(message)
{
    public string Error { get; } = message;
    public string Target { get; } = target;
}