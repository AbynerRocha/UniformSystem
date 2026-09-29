namespace UniformSystem.Exceptions.Employees;

public class EmployeeNotFoundException(
    string message = EmployeeNotFoundException.DefaultMessage,
    string target = EmployeeNotFoundException.DefaultTarget,
    string title = EmployeeNotFoundException.DefaultTitle
    )
    : EntityNotFoundException(title, message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse funcionário.";
    private const string DefaultTarget = "global";
    private const string DefaultTitle = "EMPLOYEE_NOT_FOUND";
}