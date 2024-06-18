using CP.Abstractions.Contracts;
using CP.Abstractions.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CP.Business.Helper
{
    public static class ExceptionHelper
    {
        public static int GetApiExceptionResponseCode(Exception? exception)
        {
            int statusCode = 500;

            if (exception is ValidationException)
            {
                statusCode = 400;
            }
            else if (exception is NotFoundException)
            {
                statusCode = 404;
            }

            return statusCode;
        }

        public static ValidationResponseDTO GetApiExceptionResponse(Exception? Error)
        {
            if (Error is NotFoundException)
            {
                var response = new ValidationResponseDTO
                {
                    Message = Error.Message.Equals("Exception of type 'CIB.Abstractions.Exceptions.NotFoundException' was thrown.") ? "Not Found" : Error.Message
                };
                return response;
            }
            else
            {
                string message = Error?.Message ?? "An error occurred";
                if (Error?.InnerException != null)
                {
                    message += Environment.NewLine + Error?.InnerException.Message;
                }
                var response = new ValidationResponseDTO
                {
                    Message = message
                };
                return response;
            }
        }

        public static string GetExceptionMessages(Exception e, string msgs = "")
        {
            if (e == null)
            {
                return string.Empty;
            }

            if (msgs == "")
            {
                msgs = e.Message;
            }

            if (e.InnerException != null)
            {
                msgs += "\r\nInnerException: " + GetExceptionMessages(e.InnerException);
            }

            return msgs;
        }
    }
}
