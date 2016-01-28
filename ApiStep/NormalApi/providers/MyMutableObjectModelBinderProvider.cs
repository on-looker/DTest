using NormalApi.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace NormalApi.providers
{
    public class MyMutableObjectModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            if (MyMutableObjectModelBinder.CanBindType(modelType))
            {
                return new MyMutableObjectModelBinder();
            }
            return null;
        }
    }
}