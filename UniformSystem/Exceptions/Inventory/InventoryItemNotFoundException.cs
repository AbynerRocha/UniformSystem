namespace UniformSystem.Exceptions.Inventory;

public class InventoryItemNotFoundException(
    string message = InventoryItemNotFoundException.DefaultMessage,
    string target = InventoryItemNotFoundException.DefaultTarget,
    string title = InventoryItemNotFoundException.DefaultTitle
)
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Este item não está registrado no inventário.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "ITEM_NOT_FOUND";
}