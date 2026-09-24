namespace UniformSystem.Exceptions;

public class NullParamException(
    string message,
    string target) : ParamException(message, target)
{
}