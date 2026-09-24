namespace UniformSystem.Exceptions.Employees;

public class EmployeeAlreadyExistsException(
    string message = EmployeeAlreadyExistsException.DefaultMessage,
    string target = EmployeeAlreadyExistsException.DefaultTarget)
    : EntityNotFoundException(message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse funcionário.";
    private const string DefaultTarget = "global";
}