using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace UniformSystem.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var (status, message, target) = exception switch
        {
            EntityAlreadyExistsException ex => new ErrorResponse(StatusCodes.Status409Conflict, ex.Message, ex.Target),
            EntityNotFoundException ex => new ErrorResponse(StatusCodes.Status404NotFound, ex.Message, ex.Target),
            
            InvalidOperationException ex => new ErrorResponse(StatusCodes.Status400BadRequest, ex.Message, null),
            ArgumentException ex => new ErrorResponse(StatusCodes.Status400BadRequest, ex.Message, null),
            
            InvalidParamLengthException ex => new ErrorResponse(StatusCodes.Status400BadRequest, ex.Message, ex.Target),
            _ => new ErrorResponse(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Tente novamente mais tarde.",  null)
        };
        
        if(status == StatusCodes.Status500InternalServerError)
            logger.LogError(exception, "Error not treated");
        else 
            logger.LogWarning(exception, "Request error: {ExceptionMessage}", exception.Message);
        
        httpContext.Response.StatusCode = status;
        
        await httpContext.Response.WriteAsJsonAsync(new { status, message, target }, cancellationToken);

        return true;
    }
}

public sealed record ErrorResponse(int Status, string Message, string? Target);