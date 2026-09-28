namespace UniformSystem.Exceptions.Users;

public class UniformDeliveryNotFoundException(
    string message = UniformDeliveryNotFoundException.DefaultMessage,
    string target = UniformDeliveryNotFoundException.DefaultTarget)
    : EntityNotFoundException(message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar essa entrega.";
    private const string DefaultTarget = "global";
}