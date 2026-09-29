namespace UniformSystem.Exceptions;

public class InvalidParamException(string message, string target, string title="INVALID_PARAM") : ParamException(title, message, target)
{
}