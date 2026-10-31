namespace UniformSystem.Exceptions;

public class InvalidCredentialsException(
    string message = InvalidCredentialsException.DefaultMessage,
    string target = InvalidCredentialsException.DefaultTarget,
    string title = InvalidCredentialsException.DefaultTitle)
    : DomainException(title, message, target)
{
    private const string DefaultMessage = "Credentiais inválidas.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "INVALID_CREDENTIALS";
}