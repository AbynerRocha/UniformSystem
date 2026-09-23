namespace UniformSystem.Exceptions.Employees;

public class EmployeeAlreadyExistsException : EntityNotFoundException
{
    public EmployeeAlreadyExistsException() : base("Esse funcionário não esta registrado.") { }
    public EmployeeAlreadyExistsException(string message) :  base(message) { }
    public EmployeeAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}