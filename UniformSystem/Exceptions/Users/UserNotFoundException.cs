namespace UniformSystem.Exceptions.Users;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException() : base("Usuário não encontrado.") { }
    public UserNotFoundException(string message) :  base(message) { }
    public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}