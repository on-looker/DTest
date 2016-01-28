using NormalApi.ValueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace NormalApi.ValueProviderFactorys
{
    public class DictionaryValueProviderFactory:ValueProviderFactory
    {
        public static IDictionary<string, object> values{get;set;}
        static DictionaryValueProviderFactory()
        { 
          values=new Dictionary<string,object>();
        }
        public override IValueProvider GetValueProvider(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return new DicitonaryValueProvider(values);
        }
    }
}