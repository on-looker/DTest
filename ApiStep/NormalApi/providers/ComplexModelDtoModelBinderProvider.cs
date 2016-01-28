using NormalApi.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace NormalApi.providers
{
    public class MyComplexModelDtoModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            ///直接返回ComplexModelDtoModelBinderProvider
            return new MyComplexModelDtoModelBinder();
        }
    }
}