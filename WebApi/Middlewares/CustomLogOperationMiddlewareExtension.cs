using Microsoft.AspNetCore.Builder;

namespace WebApi.Middlewares
{

    public static class CustomLogOperationMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomLogOperationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLogOperationMiddleware>();
        }
    }

}