namespace UniformSystem.Exceptions.Uniform;

public class UniformNotFoundException(
    string message = UniformNotFoundException.DefaultMessage,
    string target = UniformNotFoundException.DefaultTarget,
    string title = UniformNotFoundException.DefaultTitle
)
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse uniforme.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "UNIFORM_NOT_FOUND";
}