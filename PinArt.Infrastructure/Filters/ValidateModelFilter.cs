using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PinArt.Core.CustomEntities;
using System.Linq;

namespace PinArt.Infrastructure.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {          
                var message = string.Join(" | ", context.ModelState.Keys
                                   .SelectMany(key => context.ModelState[key].Errors
                                   .Select(x => key + ": " + x.ErrorMessage)));

                var errorDetail = new ErrorDetail()
                {
                    Status = 400,
                    Title = "Bad Request - Model Is Not Valid",
                    Message = message
                };

                context.Result = new BadRequestObjectResult(errorDetail);               
            }
        }
    }
}

