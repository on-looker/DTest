using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace NormalApi.HttpParameterBindings
{
    public class HttpRequestParameterBinding:HttpParameterBinding
    {
        public override System.Threading.Tasks.Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            string parameterName = base.Descriptor.ParameterName;
            HttpRequestMessage request = actionContext.ControllerContext.Request;
            actionContext.ActionArguments.Add(parameterName, request);
            TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
            source.SetResult(new AsyncVoid());
            return source.Task;
        }
    }
    struct AsyncVoid
    { 
    
    
    }
}