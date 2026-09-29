namespace UniformSystem.Exceptions.Users;

public class UserNotFoundException(
    string message = UserNotFoundException.DefaultMessage,
    string target = UserNotFoundException.DefaultTarget,
    string title = UserNotFoundException.DefaultTitle
)
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse usuário.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "USER_NOT_FOUND";
}