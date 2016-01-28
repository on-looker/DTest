using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace NormalApi.ValueProviderFactorys
{
    public class DictionaryValueProviderFactory:ValueProviderFactory
    {
      public static IDictionary<string ,object>
        public override IValueProvider GetValueProvider(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            throw new NotImplementedException();
        }
    }
}