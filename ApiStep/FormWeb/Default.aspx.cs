using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormWeb
{
    public partial class _Default : Page
    {
        public string name { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var response = HttpContext.Current.Response;
            //1.存在
            //
            name = this.RouteData.Values["name"] as string;
            //string rq = this.RouteData.GetRequiredString("name");
            //string rqlong =this.RouteData.Route.GetRouteData(this.Request.RequestContext.HttpContext).GetRequiredString("name");
            //string tk = this.RouteData.DataTokens["name"] as string;
            //this.Request.RequestContext.RouteData.Values.Add("name1","李四");
            RouteData rd = new RouteData();
            rd.Values.Add("age", 20);
            rd.Values.Add("name", "lifeng");
            RouteValueDictionary rvd = new RouteValueDictionary();
            rvd.Add("name", "values");
            rvd.Add("age",12);
            RequestContext requestContext = new RequestContext();
            requestContext.HttpContext = new HttpContextWrapper(HttpContext.Current);
            requestContext.RouteData = rd;
            var p1 = RouteTable.Routes.GetVirtualPath(null, null);
            var p2 = RouteTable.Routes.GetVirtualPath(null, rvd);           //Content/values?age=12
            var p3 = RouteTable.Routes.GetVirtualPath(requestContext, null);// Content/values?age=20
            var p4 = RouteTable.Routes.GetVirtualPath(requestContext, rvd);//  Content/values?age=12
            var p5 = RouteTable.Routes.GetVirtualPath(Request.RequestContext, null);// 当前访问路径为Content/Site的时候：Content/Site

            RouteValueDictionary ra = new RouteValueDictionary();
            ra.Add("age",18);
            var p6 = RouteTable.Routes.GetVirtualPath(null, ra);
            var p7 = RouteTable.Routes.GetVirtualPath(requestContext, "route2", rvd);
        }
    }
}