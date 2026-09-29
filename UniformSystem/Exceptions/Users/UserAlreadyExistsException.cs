namespace UniformSystem.Exceptions.Users;

public class UserAlreadyExistsException(
    string message = UserAlreadyExistsException.DefaultMessage,
    string target = UserAlreadyExistsException.DefaultTarget,
    string title = UserAlreadyExistsException.DefaultTitle)
    : EntityAlreadyExistsException(title, message, target)
{
    private const string DefaultMessage = "Este usuário já esta registrado.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "USER_ALREADY_EXISTS";
}