using NormalApi.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace NormalApi.providers
{
    public class MyTypeMatchModelBinderProvider : ModelBinderProvider
    {
        private static readonly IModelBinder binder = new MyTypeMathModelBinder();
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            return binder;
        }
    }
}