using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Reflection;

namespace NormalApi.Binders
{
    public class MyMutableObjectModelBinder : IModelBinder
    {
        internal static bool CanBindType(Type ModelType)
        {
            if (TypeDescriptor.GetConverter(ModelType).CanConvertFrom(typeof(string)))///MutableObjectModelBinder不支持从简单类型的模型绑定
            {
                return false;
            }
            if (ModelType == typeof(ComplexModelDto))//MutableObjectModelBinder不支持对ComplexModelDto的模型绑定
            {
                return false;
            }
            return true;
        }
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!CanBindType(bindingContext.ModelType))
            {
                return false;
            }
            if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))//前缀检查，查看valueprovider是否提供了该名称的数据
            {
                return false;
            }
            //创建目标类型的空对象
            bindingContext.Model = Activator.CreateInstance(bindingContext.ModelType);
            //创建针对目标类型的ComplexModelDto
            ComplexModelDto dto = new ComplexModelDto(bindingContext.ModelMetadata, bindingContext.PropertyMetadata.Values);
            ///创建一个子ModelBindingContext用于作为参数，直接调用HttpActionContextExtensions的里对HttpActionContext的扩展方法，进行模型绑定,命名空间:System.Web.Http.Controllers;
            ModelBindingContext subContext = new ModelBindingContext(bindingContext)
            {
                ModelMetadata = actionContext.GetMetadataProvider().GetMetadataForType(() => dto, typeof(ComplexModelDto)),
                ModelName = bindingContext.ModelName
            };
            ///，直接调用HttpActionContextExtensions的里对HttpActionContext的扩展方法Bind，进行模型绑定,命名空间:System.Web.Http.Controllers;
            actionContext.Bind(subContext);
            foreach (KeyValuePair<ModelMetadata, ComplexModelDtoResult> item in dto.Results)
            {
                ModelMetadata metadata = item.Key;
                ComplexModelDtoResult result = item.Value;
                if (result != null)
                {
                    ///
                    PropertyInfo propertyinfo = bindingContext.ModelType.GetProperty(metadata.PropertyName);
                    ///实现在Bin(l方 法之中的ModeI绑定完成之后,目 标对象相应的属性值将会保存到 CompIexMode1Dto对象的Rcsults属 性中。我们直接从中获取相应的属性值,并对创建的空
                    //对象对应的非只读属性进行赋值即可。

                    if (propertyinfo.CanWrite)
                    {
                        propertyinfo.SetValue(bindingContext.Model, result.Model);
                    }
                }
            }
            return true;
        }
    }
}