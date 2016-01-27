using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace NormalApi.Binders
{
    public class MyTypeConverterBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            //valueProvider,提供键值对？
            //ModelBinder:提供绑定组装?
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result == null)
            {
                return false;
            } try
            {
                bindingContext.Model = result.ConvertTo(bindingContext.ModelType);
                //bindingContext.ModelMetadata.ConvertEmptyStringToNull指示空字符串是否算作转换成功;这只是当Model的类型为字符串时候有用
                if (bindingContext.Model is string && string.IsNullOrWhiteSpace((string)bindingContext.Model) && bindingContext.ModelMetadata.ConvertEmptyStringToNull)
                {
                    bindingContext.Model = null;
                }
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}