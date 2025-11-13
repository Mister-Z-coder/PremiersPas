using BackendAPI.Exceptions;
using BackendAPI.Wrappers;
using BackendAPI.Wrappers.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendAPI.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            Response<object> response;
            HttpStatusCode statusCode;

            switch (exception)
            {
                case InvalidInputException invalidEx:
                    statusCode = HttpStatusCode.BadRequest;
                    response = PaginationHelper.CreateErrorResponse<object>(invalidEx.Message);
                    break;

                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    response = PaginationHelper.CreateErrorResponse<object>(notFoundEx.Message);
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    response = PaginationHelper.CreateErrorResponse<object>("Une erreur inattendue est survenue.",
                        new List<string> { exception.Message });
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

    }
}

