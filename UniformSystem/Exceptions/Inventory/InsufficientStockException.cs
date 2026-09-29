namespace UniformSystem.Exceptions.Inventory;

public class InsufficientStockException(
    string message = InsufficientStockException.DefaultMessage,
    string target = InsufficientStockException.DefaultTarget,
    string title = InsufficientStockException.DefaultTitle
    ) : DomainException(title, message, target)
{
    private const string DefaultMessage = "Estoque insulficiente.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "INSUFFICIENT_STOCK";
}