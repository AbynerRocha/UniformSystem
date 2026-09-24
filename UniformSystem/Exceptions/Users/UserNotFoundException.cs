namespace UniformSystem.Exceptions.Users;

public class UserNotFoundException(
    string message = UserNotFoundException.DefaultMessage,
    string target = UserNotFoundException.DefaultTarget)
    : EntityNotFoundException(message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse usuário.";
    private const string DefaultTarget = "global";
}