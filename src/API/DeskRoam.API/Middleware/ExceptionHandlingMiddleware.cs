using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace DeskRoam.API.Middleware;

public class ExceptionHandlingMiddleware : IExceptionHandler
{
    private readonly IWebHostEnvironment _environment;

    //private readonly ILogger _logger;

    //public ExceptionHandlingMiddleware(ILogger logger)
    //{
    //    _logger = logger;
    //}

    public ExceptionHandlingMiddleware(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
       //_logger.LogError(exception, "An unhandled exception has occurred while executing the request.");

        var problemDetails = new ProblemDetails
        {
            Title = "Oops! We couldn't process your request.",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = _environment.IsDevelopment() ? exception.Message : exception.StackTrace,
            Type = exception.GetType().Name,
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
