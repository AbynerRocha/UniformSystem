using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace UniformSystem.Exceptions;

public class GlobalExceptionHandler(ILogger logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var (status, title, detail) = exception switch
        {
            EntityAlreadyExistsException ex => (StatusCodes.Status409Conflict, "Conflito", ex.Message),
            EntityNotFoundException ex => (StatusCodes.Status404NotFound, "Não encontrado", ex.Message),
            InvalidOperationException ex => (StatusCodes.Status400BadRequest, "Requisição inválida", ex.Message),
            ArgumentException ex => (StatusCodes.Status400BadRequest, "Requisição inválida", ex.Message),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno",
                "Ocorreu um erro inesperado. Tente novamente mais tarde.")
        };
        
        if(status == StatusCodes.Status500InternalServerError)
            logger.LogError(exception, "Error not treated");
        else 
            logger.LogWarning(exception, "Bad request: {ExceptionMessage}", exception.Message);
        
        httpContext.Response.StatusCode = status;

        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path
        };
        
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}