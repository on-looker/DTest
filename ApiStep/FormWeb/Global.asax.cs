using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace FormWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.RouteExistingFiles = true;
            // 在应用程序启动时运行的代码
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteValueDictionary defaults = new RouteValueDictionary();
            defaults.Add("name", "张三");
            RouteValueDictionary constraints = new RouteValueDictionary();
            constraints.Add("name",@"[1-10]");
            RouteValueDictionary dataTokens = new RouteValueDictionary();
            dataTokens.Add("age",22);
            dataTokens.Add("httpMethod",new HttpMethodConstraint("GET"));
            RouteTable.Routes.Ignore("Content/{filename}.css/{*pathInfo}");
            //1.
            RouteTable.Routes.MapPageRoute(
                "default",
                "Content/{name}",
                "~/Default.aspx", false, defaults,null,dataTokens
                );
            RouteTable.Routes.MapPageRoute(
            "route2",
            "Route/{age}",
            "~/Default.aspx", false, defaults, null, dataTokens
            );
            //PageRouteHandler pageRou teHandler=new PageRouteHandler(RouteTable.Routes.GetVirtualPath(null,null).VirtualPath);
            //2
            Route route=new Route("Hello/{name}",new PageRouteHandler("~/Default.aspx"));
            //PageRouteHandler  routeHandler=new PageRouteHandler();
            RouteTable.Routes.Add(route);
           
        }
    }
}