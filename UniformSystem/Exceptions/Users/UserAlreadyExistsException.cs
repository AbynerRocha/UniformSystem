namespace UniformSystem.Exceptions.Users;

public class UserAlreadyExistsException(
    string message = UserAlreadyExistsException.DefaultMessage,
    string target = UserAlreadyExistsException.DefaultTarget)
    : EntityAlreadyExistsException(message, target)
{
    private const string DefaultMessage = "Este usuário já esta registrado.";
    private const string DefaultTarget = "global";
}