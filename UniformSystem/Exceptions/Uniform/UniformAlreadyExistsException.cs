namespace UniformSystem.Exceptions.Uniform;

public class UniformAlreadyExistsException(
    string message = UniformAlreadyExistsException.DefaultMessage,
    string target = UniformAlreadyExistsException.DefaultTarget)
    : EntityAlreadyExistsException(message, target)
{
    private const string DefaultMessage = "Esse uniforme já esta registrado.";
    private const string DefaultTarget = "global";
}
