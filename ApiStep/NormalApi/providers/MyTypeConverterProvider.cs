using NormalApi.Binders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace NormalApi.providers
{
    public class MyTypeConverterProvider:ModelBinderProvider
    {
        /// <summary>
        /// 可以直接由字符串转换的类型，都被视为简单类型
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            if (TypeDescriptor.GetConverter(modelType).CanConvertFrom(typeof(string)))
            {
                return new MyTypeConverterBinder();
            }
            return null;
        }
    }
}