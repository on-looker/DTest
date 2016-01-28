using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using NormalApi.filters;
using NormalApi.Models;
using System.Web.Http.ModelBinding;
using NormalApi.providers;
using System.Web.Http.ValueProviders;
using NormalApi.valueProvider;

namespace NormalApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.Formatters.Insert(0,new JsonpMediaFormatter());
            ///使用自己的ModelBinderProvider
            ///            ///使用自己的ModelBinderProvider
          //  GlobalConfiguration.Configuration.Services.RemoveAll(typeof(ModelBinderProvider), (obj) => { return true; });
          //  GlobalConfiguration.Configuration.Services.ReplaceRange(typeof(ModelBinderProvider),new ModelBinderProvider[]{new MyTypeConverterProvider()});

            //GlobalConfiguration.Configuration.Services.ReplaceRange(typeof(ModelBinderProvider), new ModelBinderProvider[]{
            //    new MyTypeConverterProvider(),
            //    new MyMutableObjectModelBinderProvider(),
            //    new MyComplexModelDtoModelBinderProvider()});
            //GlobalConfiguration.Configuration.Services.ReplaceRange(typeof(ValueProviderFactory), new ValueProviderFactory[] { new StaticValueProviderFactory() });
        }
    }
}
