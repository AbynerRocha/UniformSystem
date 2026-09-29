namespace UniformSystem.Exceptions;

public class NullParamException(
    string message,
    string target,
    string title="INVALID_PARAM") : ParamException(title, message, target)
{
}