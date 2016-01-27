using NormalApi.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.Controllers;
namespace NormalApi.Binders
{
    public class MyComplexModelDtoModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ComplexModelDto dto = bindingContext.Model as ComplexModelDto;
            if (dto == null)
            {
                return false;
            }
            foreach (ModelMetadata medadata in dto.PropertyMetadata)
            {
                ModelBindingContext subcontext = new ModelBindingContext(bindingContext)
                {
                    ModelMetadata = medadata,
                    //创建前缀形式的ModelName
                    ModelName = ModelNameBuilder.CreatePropertyModelName(bindingContext.ModelName, medadata.PropertyName)
                };
                if (actionContext.Bind(subcontext))
                {
                    dto.Results[medadata] = new ComplexModelDtoResult(subcontext.Model, subcontext.ValidationNode);
                }

            }
            return true;
            //  在实现的BindModd方法中,如果当前Modc1BindiⅡ gContext 的Modcl属 性不是一个CompIexModolDto对象,
            //我们会直接返回Fdsc。 接下来针对描述属 性的每个Mo山;lMetadata创 建当前ModeIBindingContext的 子上下文
            //,然 后调用当前 IIttpActioⅡContc灶 的Bi血 方法针对它实施新—轮的Mode1绑 定。Mode1绑 定成功完成之后 ,
            //作为子上下文的ModeIBiΠdiⅡgContext中 将包含属性对应的值和验证结果,我们将它们添加 到ComplexMo山 lDto
            //的 Results属 性中,Mut汕 1co切ectModelBhder为 空对象设置的属性值 就来源于此。 
        }
    }
}