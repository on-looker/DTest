using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace NormalApi.Binders
{
    public class MyTypeMathModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result == null)
            {
                return false;
            }
            var rawValue = result.RawValue;
            if (bindingContext.ModelType.IsInstanceOfType(rawValue))
            {
                if (rawValue is string && string.IsNullOrWhiteSpace((string)rawValue) && bindingContext.ModelMetadata.ConvertEmptyStringToNull)
                {
                    rawValue = null;
                }
                bindingContext.Model = rawValue;
                return true;

            }
            return false;
        }
    }
}