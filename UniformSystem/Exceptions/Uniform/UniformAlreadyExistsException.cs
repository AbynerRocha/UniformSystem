namespace UniformSystem.Exceptions.Uniform;

public class UniformAlreadyExistsException(
    string message = UniformAlreadyExistsException.DefaultMessage,
    string target = UniformAlreadyExistsException.DefaultTarget,
    string title = UniformAlreadyExistsException.DefaultTitle
)
    : EntityAlreadyExistsException(title, message, target)
{
    private const string DefaultMessage = "Esse uniforme já esta registrado.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "UNIFORM_ALREADY_EXISTS";
}