using UniformSystem.Constants;

namespace UniformSystem.Exceptions;

public class ParamException(string title, string message, string target) : Exception(message)
{
    public string Title { get; } = title;
    public string Target { get; } = target;
}