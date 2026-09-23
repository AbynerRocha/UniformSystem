namespace UniformSystem.Exceptions.Users;

public class UserAlreadyExistsException : EntityAlreadyExistsException
{
    public UserAlreadyExistsException() : base("Este usuário já esta registrado.") { }
    public UserAlreadyExistsException(string message) : base(message) { }
    public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}