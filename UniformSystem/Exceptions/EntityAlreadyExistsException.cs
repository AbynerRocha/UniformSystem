namespace UniformSystem.Exceptions;

public class EntityAlreadyExistsException(string title, string message, string target) : EntityException(title, message, target);
