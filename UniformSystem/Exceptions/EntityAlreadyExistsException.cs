namespace UniformSystem.Exceptions;

public class EntityAlreadyExistsException(string message, string target) : EntityException(message, target);
