namespace UniformSystem.Exceptions.Employees;

public class EmployeeAlreadyExistsException(
    string message = EmployeeAlreadyExistsException.DefaultMessage,
    string target = EmployeeAlreadyExistsException.DefaultTarget,
    string title = EmployeeAlreadyExistsException.DefaultTitle
)
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse funcionário.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "EMPLOYEE_ALREADY_EXISTS";
}