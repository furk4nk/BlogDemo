using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ActionFilters
{
    public class CustomActionFilterAttribute : IActionFilter
    {
        //aksiyon gerçekleştikten sonra  
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var val=context.HttpContext.Response.StatusCode;
            //throw new NotImplementedException();
        }

        //aksiyon gerçekleşmeden önce 
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var val = context.HttpContext.Response.StatusCode;
        }
    }
}
