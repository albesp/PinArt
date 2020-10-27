using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PinArt.Core.Exceptions;
using System.Net;

namespace PinArt.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException) || 
                context.Exception.GetType() == typeof(BadRequestException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }

            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                var validation = new
                {
                    Status = 404,
                    Title = "Not Found",
                    Detail = exception.Message
                };

                //var json = new
                //{
                //    errors = new[] { validation }
                //};

                context.Result = new NotFoundObjectResult(validation);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true;
            }
        }
    }
}