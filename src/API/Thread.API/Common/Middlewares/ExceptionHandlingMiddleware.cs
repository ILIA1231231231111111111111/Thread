using System.Net;
using System.Text.Json;
using Thread.API.Common.Models;

#nullable enable

namespace Thread.API.Common.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);

        var code = ex switch
        {
            //

            _ => HttpStatusCode.InternalServerError
        };
        
        var errors = new List<string> { ex.Message };
        
        var response = JsonSerializer.Serialize(ApiResponse<string>.Failure(code, errors));
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(response);
    }
}