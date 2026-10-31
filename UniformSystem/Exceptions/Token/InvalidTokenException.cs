namespace UniformSystem.Exceptions.Token;

public class InvalidTokenException(string message="The sent token is not valid") : EntityException("Invalid token", message, "system");