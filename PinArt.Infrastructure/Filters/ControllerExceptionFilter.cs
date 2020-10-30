using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PinArt.Core.Exceptions;
using System.Net;
using PinArt.Core.CustomEntities;

namespace PinArt.Infrastructure.Filters
{
    public class ControllerExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {

            // Bad Request
            if (context.Exception.GetType() == typeof(BadRequestException))
            {
                var exception = (BadRequestException)context.Exception;

                var errorDetail = new ErrorDetail()
                {
                    Status = 400,
                    Title = "Bad Request",
                    Message = exception.Message
                };               

                context.Result = new BadRequestObjectResult(errorDetail);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }

            //Bad Request - Bussiness Exception
            if (context.Exception.GetType() == typeof(BusinessException))            
            {
                var exception = (BusinessException)context.Exception;

                var errorDetail = new ErrorDetail()
                {
                    Status = 400,
                    Title = "Bad Request - Business Exception",
                    Message = exception.Message
                };

                context.Result = new BadRequestObjectResult(errorDetail);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }

            // Bad Request - ModelStateException
            if (context.Exception.GetType() == typeof(ModelStateException))
            {
                var exception = (ModelStateException)context.Exception;

                var errorDetail = new ErrorDetail()
                {
                    Status = 400,
                    Title = "Bad Request - ModelStateException",
                    Message = exception.Message
                };

                context.Result = new BadRequestObjectResult(errorDetail);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }


            //Not Found
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;

                var errorDetail = new ErrorDetail()
                {
                    Status = 404,
                    Title = "Not Found",
                    Message = exception.Message
                };               

                context.Result = new NotFoundObjectResult(errorDetail);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.ExceptionHandled = true;
            }

            
        }
    }
}