namespace UniformSystem.Exceptions.Uniform;

public class UniformAlreadyExistsException : EntityAlreadyExistsException
{
    public UniformAlreadyExistsException() : base("Esse uniforme já existe.") { }
    public UniformAlreadyExistsException(string message) :  base(message) { }
    public UniformAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}
