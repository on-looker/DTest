using NormalApi.Models;
using NormalApi.providers;
using NormalApi.valueProvider;
using NormalApi.ValueProviderFactorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace NormalApi.Controllers
{
    public class BindController : ApiController
    {
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            StaticValueProviderFactory.Clear();
            StaticValueProviderFactory.Add("张三", "12");
            StaticValueProviderFactory.Add("关于", "10");
            StaticValueProviderFactory.Add("10", "20");
            StaticValueProviderFactory.Add("Name", "张三三");
            StaticValueProviderFactory.Add("Age", "22");
            StaticValueProviderFactory.Add("Address", "四川省成都市高新区");
            StaticValueProviderFactory.Add("Address.Province", "四川省");
            StaticValueProviderFactory.Add("Address.City", "成都市");
            StaticValueProviderFactory.Add("Address.Area", "高新区");
            DictionaryValueProviderFactory.values.Add("animal", new Cat { Age = 2, Name = "xiaomao", Tail = "0.2", type = "猫科" });
        }
        [AcceptVerbs("get")]
        [Route("GetBindContact")]
        public Contact GetContact(Contact contact)//加上【ModelBinder】反而无法正常调用ValueProvider
        {

            return contact;
        }
        public void EnumersBind(IEnumerable<int> numbers)
        {

            var result = numbers;
        }
        [Route("EnumersBind")]
        public void EnumersBind(IEnumerable<Contact> contacts)
        {

        }
        [HttpPost]
        [Route("BindContact")]
        public void EnumersBind(IEnumerable<Contact> contacts1, IEnumerable<Contact> contactss)
        {

        }
        [HttpPost]
        [Route("SameBind")]
        public void EnumersBind([FromBody]Contact contacts1, [FromBody] Contact contacts2)
        {

        }
        [HttpGet]
        [Route("GetAnimal")]
        public Animal GetAnimal([ValueProvider(typeof(DictionaryValueProviderFactory))]Animal animal)
        {
            return animal;

        }

        [HttpGet]
        [Route("GetByModelState")]
        public dynamic GetAll([ValueProvider(typeof(DictionaryValueProviderFactory))]Animal animal)
        {
            IDictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var key in this.ModelState.Keys)
            {

                dic.Add(key, this.ModelState[key].Value.RawValue);
            }
            return dic;
        }
    }
}
