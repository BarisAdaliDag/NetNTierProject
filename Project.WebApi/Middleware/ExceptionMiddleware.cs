using Project.Bll.Exceptions;
using System.Net;
using System.Text.Json;

namespace Project.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            Console.WriteLine("✅ ExceptionMiddleware OLUŞTURULDU");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hata oluştu: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Bir hata oluştu";

            // Exception tipine göre status code belirle
            switch (exception)
            {
                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound; // 404
                    message = notFoundEx.Message;
                    break;

                case BadRequestException badRequestEx:
                    statusCode = HttpStatusCode.BadRequest; // 400
                    message = badRequestEx.Message;
                    break;

                case ConflictException conflictEx:
                    statusCode = HttpStatusCode.Conflict; // 409
                    message = conflictEx.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError; // 500
                    message = "Sunucu hatası oluştu";
                    break;
            }

            // Response oluştur
            var response = new
            {
                statusCode = (int)statusCode,
                message = message,
                timestamp = DateTime.Now
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
