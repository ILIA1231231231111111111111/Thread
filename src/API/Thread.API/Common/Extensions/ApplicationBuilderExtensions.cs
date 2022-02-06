using Thread.API.Common.Middlewares;
#nullable enable

namespace Thread.API.Common.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
        return builder;
    }
}