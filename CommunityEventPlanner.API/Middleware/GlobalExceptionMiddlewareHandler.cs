using CommunityEventPlanner.API.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;

namespace CommunityEventPlanner.API.Middleware
{
    public class GlobalExceptionMiddlewareHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddlewareHandler> _logger;

        public GlobalExceptionMiddlewareHandler(RequestDelegate next, ILogger<GlobalExceptionMiddlewareHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred : {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new ErrorDetails(StatusCodes.Status500InternalServerError, "An unexpected error occurred.", ex.Message);

            return httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
