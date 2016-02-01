using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders.Providers;

namespace NormalApi.HttpParameterBindings
{
    public class MyModelBinderParameterBinding:HttpParameterBinding,IValueProviderParameterBinding
    {
        public IEnumerable<System.Web.Http.ValueProviders.ValueProviderFactory> ValueProviderFactories
        {
            get { throw new NotImplementedException(); }
        }
        public override System.Threading.Tasks.Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            CompositeValueProviderFactory valueproviderFactory = new CompositeValueProviderFactory(this.ValueProviderFactories);
            string parameterName = base.Descriptor.ParameterName;
            Type parameterType = base.Descriptor.ParameterType;
            string prefix = base.Descriptor.Prefix;
            ModelBindingContext context = new ModelBindingContext()
            {
                ModelName = prefix ?? parameterName,
                FallbackToEmptyPrefix = prefix == null,
                ModelMetadata = metadataProvider.GetMetadataForType(null, parameterType),
                ModelState = actionContext.ModelState,
                ValueProvider = valueproviderFactory.GetValueProvider(actionContext)

            };
            object argument="";
           // this.Binder.BindModel() ? context.Model : base.Descriptor.DefaultValue ;
            base.SetValue(actionContext, argument);
            TaskCompletionSource<AsyncVoid> Source = new TaskCompletionSource<AsyncVoid>();
            Source.SetResult(new AsyncVoid());
            return Source.Task;
        }
    }
    private struct AsyncVoid
    { 
    
    }
   
}