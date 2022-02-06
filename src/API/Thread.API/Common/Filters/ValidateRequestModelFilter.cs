using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Thread.API.Common.Models;

namespace Thread.API.Common.Filters;

public class ValidateRequestModelFilter : Attribute, IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(modelError => modelError.ErrorMessage);

            context.Result = new BadRequestObjectResult(ApiResponse<string>.Failure(HttpStatusCode.BadRequest, errors));
        }

        await next();
    }
}