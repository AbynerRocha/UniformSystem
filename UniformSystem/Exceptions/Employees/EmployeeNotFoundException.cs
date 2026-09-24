namespace UniformSystem.Exceptions.Employees;

public class EmployeeNotFoundException(
    string message = EmployeeNotFoundException.DefaultMessage,
    string target = EmployeeNotFoundException.DefaultTarget)
    : EntityNotFoundException(message, target)
{
    private const string DefaultMessage = "Não foi possível encontrar esse funcionário.";
    private const string DefaultTarget = "global";
}