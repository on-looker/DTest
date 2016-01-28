using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NormalWeb.filters
{
    public class PreFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RouteData.Values.Add("name1","Li");
            filterContext.RequestContext.RouteData.Values.Add("name2","Zh");
           base.OnActionExecuting(filterContext);
        }
    }
}