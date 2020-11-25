using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinArt.Core.CustomEntities;
using System.Net;


namespace PinArt.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public void Error()
        {
            var contextFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = contextFeature?.Error; // Your exception         

            int status;
            string title;
            string message = exception.Message;

            switch (exception.GetType().Name)
            {
                case "NotFoundException":
                    status = (int)HttpStatusCode.NotFound;
                    title = "Not Found";
                    break;

                case "BadRequestException":
                    status = (int)HttpStatusCode.BadRequest;
                    title = "Bad Request";
                    break;

                case "UnauthorizedException":
                    status = (int)HttpStatusCode.Unauthorized;
                    title = "Unauthorized";
                    break;

                default:
                    status = (int)HttpStatusCode.InternalServerError;
                    title = "Internal Server Error";
                    break;
            }

            var error = new ErrorDetail
            {
                Status = status,
                Title = title,
                Message = message
            }.ToString();

            Response.StatusCode = status;
            Response.ContentType = "application/json";
            Response.WriteAsync(error);
        }

        [Route("error/{code:int}")]

        public void ErrorNotHandle(int code)
        {

            var contextFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
        
            int status;
            string title;
            string message;
            string origen = contextFeature.OriginalPath;

            switch (code)
            {
                case 404:
                    status = code;
                    title = "Not Found";
                    message = "El recurso no existe: " + origen;
                    break;

                case 401:
                    status = code;
                    title = "Unauthorized";
                    message = "No tiene acceso al recurso: " + origen;
                    break;

                case 403:
                    status = code;
                    title = "Forbidden";
                    message = "El Usuario No tiene permisos para el recurso: " + origen;
                    break;

                default:
                    status = (int)HttpStatusCode.InternalServerError;
                    title = "Internal Server Error";
                    message = "Error interno generado en la ruta:" + origen;
                    break;
            }

            var error = new ErrorDetail
            {
                Status = status,
                Title = title,
                Message = message
            }.ToString();

            Response.StatusCode = status;
            Response.ContentType = "application/json";
            Response.WriteAsync(error);
        }
    }
}