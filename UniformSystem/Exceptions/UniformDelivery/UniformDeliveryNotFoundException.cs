namespace UniformSystem.Exceptions.Users;

public class UniformDeliveryNotFoundException(
    string message = UniformDeliveryNotFoundException.DefaultMessage,
    string target = UniformDeliveryNotFoundException.DefaultTarget,
    string title = UniformDeliveryNotFoundException.DefaultTitle
)
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar essa entrega.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "DELIVERY_NOT_FOUND";
}