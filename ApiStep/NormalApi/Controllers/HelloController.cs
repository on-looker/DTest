using NormalApi.Binders;
using NormalApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.Routing;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;
using System.Web.Http.WebHost;
using System.Web.Http.WebHost.Routing;

namespace NormalApi.Controllers
{
    public class HelloController : ApiController
    {
       
        //public dynamic Get([FromBody]string id)
        //{

            
        //    var items = GetNO();
        //    foreach (var i in items)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    var list = GetNOList();
        //    foreach (var i in list)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    string routeTemplate = "api/{controller}/{action}";
        //    HttpRoute route1 = new HttpRoute(routeTemplate);
        //    IHttpRouteConstraint constraint = new HttpMethodConstraint(HttpMethod.Get);
        //    route1.Constraints.Add("method", constraint);
        //    HttpRequestMessage requet1 = new HttpRequestMessage(HttpMethod.Get, "http://www.oks.com/api/user/info?name=zhang");
        //    HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, "http://www.oks.com/api/user/info?name=zhang");
        //    string root1 = "/";
        //    string root2 = "/api/";
        //    IHttpRouteData r1 = route1.GetRouteData(root1, requet1);
        //    IHttpRouteData r2 = route1.GetRouteData(root1, request2);
        //    IHttpRouteData r3 = route1.GetRouteData(root2, requet1);
        //    IHttpRouteData r4 = route1.GetRouteData(root2, request2);
        //    return "你好啊";
        //    HttpControllerHandler handler1;
        //    HttpMessageHandler handler;
        //    HttpControllerRouteHandler routeHandler;
        //    DelegatingHandler delehandelr;
        //    HttpServer server=new HttpServer();
        //    HttpActionDescriptor actiond;
        //    //HttpRoutingDispatcher dispatcher=new HttpRoutingDispatcher();
        //    //HttpControllerDispatcher var1;
        //   // IHttpController;
        //    DefaultHttpControllerTypeResolver a;
        //    IHttpControllerSelector b;
        //    //HttpControllerDescriptor 
        //    // EmptyResolver.Instance
        //    //ReflectedHttpActionDescriptor
        //    AcceptVerbsAttribute c;
        //    HttpParameterDescriptor de;
        //    ReflectedHttpParameterDescriptor des;
        //    ReflectedHttpActionDescriptor s;
        //    IHttpActionSelector f;
        //    RouteDataValueProvider gs;
        //    QueryStringValueProvider afas;
        //    CompositeValueProvider jsj;
        //    ValueProviderFactory fs;
        //    RouteDataValueProviderFactory rdp;
        //    QueryStringValueProviderFactory qsf;
        //    ValueProviderAttribute asdsa;
        //    ValueProviderFactory prf;
        //ArrayModelBinderProvider  dasd;
        //CompositeModelBinder asddsa;
        //TypeConverterModelBinder asdds;
        //TypeConverterModelBinderProvider daadad;
        // IModelBinder 
        //}

        [Route("GetHeader")]
        public CommonHeader GetHeaders(CommonHeader header,[FromBody]User usr)
        {
            return header;
        }
        public dynamic GetServices<T>()
        {
            ComplexModelDto modto;
            MutableObjectModelBinder b1;
            ComplexModelDtoModelBinder b2;
            MutableObjectModelBinderProvider p1;
            ComplexModelDtoModelBinderProvider p2;
            CollectionModelBinder<T> sa;
            ArrayModelBinder<T> dasaad;
            ArrayModelBinderProvider asdadad;
            //DictionaryModelBinder<TKey, TValue> asdads;
            DictionaryModelBinderProvider aaddaads;
            //KeyValuePairModelBinder<TKey, TValue> addas;
            TypeMatchModelBinder aaddaad;
           // GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),new MyHttpControllerActivator(unitycontainer));
           // GlobalConfiguration.Configuration.DependencyResolver = new MydenpendencyResolver();
            return null;

        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            IDependencyScope scope = request.GetDependencyScope();
            object httpController = scope.GetService(controllerType) ?? Activator.CreateInstance(controllerType);
            return httpController as IHttpController;
        }
  
        //public virtual IHttpController CreateController(HttpRequestMessage request)
        //{
        //    return this.Configuration.Services.GetHttpControllerActivator()
        //        .Create(request, this, this.ControllerType);
        //}


        public virtual ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
        {
            List<Type> types=new List<Type>();
            //foreach (var assembly in assembliesResolver.GetAssemblies()//遍历每个程序集
            //{
            //    foreach (var type in assembly.GetTypes())//遍历每个类型
            //    {
            //        if (this.IsControllerTypePredicate(type))//使用自己的属性委托判断是否是合法的HttpController:判断规则
            //            //1.是一个外部可见(1sⅥsibIe=true)的 实例(1sAbstract=fa1se)类 (IsClass=true)
            //            //2.类型直接或耆间接实现了接口IHttpController。
            //            //3.类型名称必须以“Con廿oller” 为后缀,但是不区分大小写(即 可以使用“controller” 作为后缀 
            //        {
            //            types.Add(type);
            //        }

            //    }
            //}
            return types;
        }

        [HttpGet]
        [Route("CreateController")]
        public async Task<dynamic> CreateConroller()
        {
            HttpControllerContext context=new HttpControllerContext();
            DemoController controller=new DemoController();
            HttpRequestMessage mes=new HttpRequestMessage(HttpMethod.Get, "/api/Demo/get");
            context.Request = mes;
            controller.ControllerContext = context;
            controller.Initiliaze(context);
            var result = await controller.ExecuteAsync(context, new CancellationToken(false));
            return result;
        }

        [Route("GetHander")]
        public dynamic GetHanders()
        { 
            //1)配置Handler
         HttpConfiguration config=new HttpConfiguration();
            config.MessageHandlers.Add(new DeleHandlerFirst());
            config.MessageHandlers.Add(new DeleHandlerSecond());
          config.MessageHandlers.Add(new DeleHandlerThird());

            MyHttpServer server=new MyHttpServer(config);
           var result1= HandlerChains(server);
            server.Initialise();
            var result2 = HandlerChains(server);
            return result2;
            //2)配置Handler
            HttpServer _server=new HttpServer(config);
            _server.Configuration.MessageHandlers.Add(new DeleHandlerFirst());
        }

        [NonAction]
        public IEnumerable<string> HandlerChains(DelegatingHandler handler)
        {
            List<string> names=new List<string>();
            DelegatingHandler temp = handler;
            names.Add(temp.GetType().Name);
            while (temp!=null&&temp.InnerHandler!=null)
            {
               names.Add(temp.InnerHandler.GetType().Name);
                temp = temp.InnerHandler as DelegatingHandler;
            }
            return names;
        }


        [NonAction]
        private static IEnumerable<string> GetNO()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return "NO:" + i + ";";
            }

        }

        private static IEnumerable<string> GetNOList()
        {
            List<string> list=new List<string>();
                for (int i = 0; i < 5; i++)
            {
                    list.Add("List-NO:"+i+";");
            }
            return list;
        }
    }



    /// <summary>
    /// 自定义HttpServer，开放了HttpServer的Initialize
    /// </summary>
    public class MyHttpServer : HttpServer
    {
        public MyHttpServer(HttpConfiguration configuration)
            : base(configuration)
        { 
        }

        public new void Initialise()
        {
            base.Initialize();
        }
    
    }

    public class DeleHandlerFirst : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content= await base.SendAsync(request, cancellationToken);
            content.Headers.Add("first add","1");
            return content;

        }
    }
    public class DeleHandlerSecond : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
          var content= await base.SendAsync(request, cancellationToken);
            content.Headers.Add("second add","2");
            return content;
        }
    }
    public class DeleHandlerThird : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = await base.SendAsync(request, cancellationToken);
            content.Headers.Add("third add", "3");
            return content;
        }
    }
}
