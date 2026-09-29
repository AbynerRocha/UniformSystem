using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniformSystem.Exceptions.Inventory;

namespace UniformSystem.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var (status, title, message, target) = exception switch
        {
            ParamException ex => new ErrorResponse(StatusCodes.Status400BadRequest, ex.Title, ex.Message, ex.Target),
            
            EntityAlreadyExistsException ex => new ErrorResponse(StatusCodes.Status409Conflict,ex.Title, ex.Message, ex.Target),
            EntityNotFoundException ex => new ErrorResponse(StatusCodes.Status404NotFound, ex.Title, ex.Message, ex.Target),
            
            InsufficientStockException ex => new ErrorResponse(StatusCodes.Status422UnprocessableEntity, ex.Title, ex.Message, ex.Target),
            
            InvalidOperationException ex => new ErrorResponse(StatusCodes.Status400BadRequest, "BAD_REQUEST", ex.Message, null),
            ArgumentException ex => new ErrorResponse(StatusCodes.Status400BadRequest, "BAD_REQUEST", ex.Message, null),
            
            _ => new ErrorResponse(StatusCodes.Status500InternalServerError, "SERVER_ERROR", "Ocorreu um erro inesperado. Tente novamente mais tarde.",  null)
        };
        
        if(status == StatusCodes.Status500InternalServerError)
            logger.LogError(exception, "Error not treated");
        else 
            logger.LogWarning(exception, "Request error: {ExceptionMessage}", exception.Message);
        
        httpContext.Response.StatusCode = status;
        
        await httpContext.Response.WriteAsJsonAsync(new { status, title, message, target }, cancellationToken);

        return true;
    }
}

public sealed record ErrorResponse(int Status, string Title, string Message, string? Target);