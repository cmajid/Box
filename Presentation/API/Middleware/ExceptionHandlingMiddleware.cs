using System;
using System.Net;
using System.Text.Json;
using Box.API.Models;

namespace Box.API.Middleware
{


    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ErrorResponse
            {
                IsSucceed = false
            };
            switch (exception)
            {
                case ApplicationException ex:
                    if (ex.Message.Contains("Invalid Token"))
                    {
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorResponse.Messages.Add(ex.Message);
                        break;
                    }
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Messages.Add(ex.Message);
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Messages.Add("Internal server error!");
                    break;
            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}


