namespace UniformSystem.Exceptions;

public class EntityNotFoundException(string message, string target, string title) : EntityException(title, message, target);