namespace UniformSystem.Exceptions.Uniform;

public class UniformNotFoundException : EntityNotFoundException
{
    public UniformNotFoundException() : base("Uniforme não encontrado.") { }
    public UniformNotFoundException(string message) :  base(message) { }
    public UniformNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}