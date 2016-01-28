using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace NormalApi.Binders
{
    public class MyCollectionModelBinder<TElement>:IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
            {
                return false;
            }
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return false;
        }
    }
}