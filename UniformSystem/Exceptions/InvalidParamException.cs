namespace UniformSystem.Exceptions;

public class InvalidParamException(string message, string target) : ParamException(message, target)
{
}