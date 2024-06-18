using CP.Abstractions.Exceptions;
using CP.Abstractions.Models;
using CP.Business.Helper;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension class that adds support for handling exceptions
    /// </summary>
    public static class CustomExceptionHandler
    {
        /// <summary>
        /// AppSettings
        /// </summary>
        public static AppSettings AppSettings { get; set; } = null!;

        /// <summary>
        /// Extension method that adds global support for handling exceptions
        /// </summary>
        public static void HandleException(IApplicationBuilder exceptionHandlerApp)
        {
            exceptionHandlerApp.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                if (exceptionHandlerPathFeature?.Error is ValidationException)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else if (exceptionHandlerPathFeature?.Error is NotFoundException)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else if (exceptionHandlerPathFeature?.Error is FoundException)
                {
                    context.Response.StatusCode = StatusCodes.Status302Found;
                }

                var response = ExceptionHelper.GetApiExceptionResponse(exceptionHandlerPathFeature?.Error);
                string json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            });
        }
    }
}
