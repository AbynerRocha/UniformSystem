namespace UniformSystem.Exceptions.Employees;

public class EmployeeNotFoundException : EntityNotFoundException
{
    public EmployeeNotFoundException() : base("Funcionário não encontrado.") { }
    public EmployeeNotFoundException(string message) :  base(message) { }
    public EmployeeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}