using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Assembly.Load("BlankWebApi");
            HttpSelfHostConfiguration configuration=new HttpSelfHostConfiguration("http://localhost/selfhost");
            using (HttpSelfHostServer server = new HttpSelfHostServer(configuration))
            {
                server.Configuration.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
               );
                server.OpenAsync();
                Console.ReadKey();
            }
            HttpBinding binding=new HttpBinding();

        }
    }
}
