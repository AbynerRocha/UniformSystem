namespace UniformSystem.Exceptions;

public class EntityAlreadyExistsException(string message, string target, string title) : EntityException(title, message, target);
