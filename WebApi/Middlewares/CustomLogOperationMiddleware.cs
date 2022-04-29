using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomLogOperationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomLogOperationMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            _loggerService=loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            string message = "[Request]    HTTP " + context.Request.Method + " - " + context.Request.Path;
            _loggerService.Write(message);
            await _next(context);


            message = "[Response]   HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _loggerService.Write(message);

            watch.Stop();

        }
    }


}