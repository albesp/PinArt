using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PinArt.Core.Exceptions;
using System;
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
                                 
                throw new ModelStateException("The Model Is Not Valid: " + message);

                // context.Result = new BadRequestObjectResult(context.ModelState);
                //var message = string.Join(" | ", context.ModelState.Values
                //                   .SelectMany(v => v.Errors.)
                //                   .Select(e =>  e.ErrorMessage + e. context.ModelState.Keys));
                //throw new ModelStateException("The Model Is Not Valid: " + message);

                //context.Result = new BadRequestObjectResult(context.ModelState.);
            }
        }
    }
}

