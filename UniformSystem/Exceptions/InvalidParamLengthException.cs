namespace UniformSystem.Exceptions;

public class InvalidParamLengthException(
    string message,
    string target,
    string title="INVALID_PARAM") : ParamException(title, message, target)
{
}