namespace UniformSystem.Exceptions.Uniform;

public class UniformNotFoundException(
    string message = UniformNotFoundException.DefaultMessage,
    string target = UniformNotFoundException.DefaultTarget)
    : EntityNotFoundException(message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse uniforme.";
    private const string DefaultTarget = "global";
}