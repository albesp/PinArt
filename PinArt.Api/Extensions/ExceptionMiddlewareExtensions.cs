using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PinArt.Core.CustomEntities;
using System.Net;

namespace PinArt.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                   context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                   context.Response.ContentType = "application/json";
                   var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                   if (contextFeature != null)
                   {                            
                       await context.Response.WriteAsync(new ErrorDetail()
                       {
                           Status = context.Response.StatusCode,
                           Title = "Internal Server Error.",
                           Message = contextFeature.Error.Message
                       }.ToString()); ;
                   }
                });
            });
        }
    }    
}
