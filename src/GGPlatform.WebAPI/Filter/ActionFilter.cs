using GGPlatform.WebAPI.Filter;
using GGPlatform.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI
{
    public class ActionFilter : IActionFilter
    {
        public  void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var reuslData = new ResultData(); ;

                //foreach (var item in context.ModelState.Values)
                //{
                //    foreach (var error in item.Errors)
                //    {
                //        reuslData.Msg += error.ErrorMessage;
                //        reuslData.State = Enum.Status.Fail.ToString();
                //        reuslData.Code = -1;
                //    }
                //}

                //context.Result = new JsonResult(reuslData);
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
