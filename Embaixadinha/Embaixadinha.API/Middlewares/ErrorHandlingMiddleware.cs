using Newtonsoft.Json;
using System.Net;

namespace Embaixadinha.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception.Message.Contains("Host is not allowed"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return context.Response.WriteAsync($"Host is not allowed");
            }

            var errorModel = new
            {
                Data = "error 500",
                Notifications = new
                {
                    Key = nameof(exception),
                    Code = $"Unexpect Error on execution, ex details: {exception.Message}"
                }
            };

            var result = JsonConvert.SerializeObject(errorModel);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(result);
        }
    }
}
