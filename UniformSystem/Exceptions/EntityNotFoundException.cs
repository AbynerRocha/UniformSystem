namespace UniformSystem.Exceptions;

public class EntityNotFoundException(string message, string target) : EntityException(message, target);