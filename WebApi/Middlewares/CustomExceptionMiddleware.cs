using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {        
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            _loggerService=loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                await HandleException(context, e);
            }
        }

        private Task HandleException(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + e.Message;

            _loggerService.Write(message);


            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }
}