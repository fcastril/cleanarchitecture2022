using API.Errors;
using Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace API.Middleware
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
                HttpStatusCode responseStatusCode = HttpStatusCode.InternalServerError;
                string result = string.Empty;
                switch (ex)
                {
                    case NotFoundException notFoundException:
                        responseStatusCode = HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        responseStatusCode = HttpStatusCode.BadRequest;
                        string validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(responseStatusCode, ex.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        responseStatusCode = HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(responseStatusCode, ex.Message, ex.StackTrace));

                context.Response.StatusCode = (int)responseStatusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
