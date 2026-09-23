namespace UniformSystem.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base("Não foi possível encontrar esse dado.") { }
    public EntityNotFoundException(string message) : base(message) { }
    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
}