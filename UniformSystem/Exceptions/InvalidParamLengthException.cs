namespace UniformSystem.Exceptions;

public class InvalidParamLengthException(
    string message,
    string target) : ParamException(message, target)
{
}