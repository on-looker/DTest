using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders.Providers;
namespace NormalApi.Attributes
{
    public class MyFromUriAttribute:ModelBinderAttribute
    {
        public override IEnumerable<System.Web.Http.ValueProviders.ValueProviderFactory> GetValueProviderFactories(System.Web.Http.HttpConfiguration configuration)
        {
            foreach (ValueProviderFactory factory in base.GetValueProviderFactories(configuration))
            {
                if (factory is  object) //IUriValueProviderFactory)
                {
                    yield return factory;
                }
            
            }
        }
    }
}