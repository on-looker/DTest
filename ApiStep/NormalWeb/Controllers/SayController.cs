using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NormalWeb.filters;

namespace NormalWeb.Controllers
{
    public class SayController : Controller
    {
        [PreFilter]
        //
        // GET: /Say/
        public ActionResult Index(string name = "defalut")
        {
             MvcRouteHandler mvchandler=new MvcRouteHandler();
           //  MvcHandler mhandler=new MvcHandler();
          //  PageRouteHandler handlerpage=new PageRouteHandler();
            var rq= this.RouteData.GetRequiredString("name");
            var dk = this.RouteData.DataTokens["name1"];
           // var path = this.RouteData.Route.GetVirtualPath();
            return Content("你好:" + name);
        }
    }
}