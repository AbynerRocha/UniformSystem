namespace UniformSystem.Exceptions;

public class EntityNotFoundException(string title, string message, string target) : EntityException(title, message, target);