using System.Net;

namespace CleanArchitecture.API.Errors
{
    public class CodeErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public CodeErrorResponse(HttpStatusCode statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultStatusCode(statusCode);
        }

        private string GetDefaultStatusCode(HttpStatusCode statusCode)
        {
            return (int)statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tiene autorización para este recurso",
                404 => "No se encontró el recurso solicitado",
                500 => "Se generaron errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
