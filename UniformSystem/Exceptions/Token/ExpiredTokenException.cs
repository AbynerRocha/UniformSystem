using UniformSystem.Constants;

namespace UniformSystem.Exceptions.Token;

public class ExpiredTokenException(string message="Sessão expirada") : EntityException("EXPIRED_TOKEN", message, ExceptionsTargets.Global);