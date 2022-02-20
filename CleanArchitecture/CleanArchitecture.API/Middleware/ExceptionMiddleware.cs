using CleanArchitecture.API.Errors;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                CodeErrorException response;

                HttpStatusCode responseStatusCode = context.Response.StatusCode == 200
                                                    ? HttpStatusCode.InternalServerError
                                                    : (HttpStatusCode)context.Response.StatusCode;
                context.Response.StatusCode = (int)responseStatusCode;

                response = _env.IsDevelopment() 
                    ? new CodeErrorException(responseStatusCode, ex.Message, ex.StackTrace)
                    : new CodeErrorException(HttpStatusCode.InternalServerError, ex.Message);

                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                string json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
