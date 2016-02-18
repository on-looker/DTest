using NormalApi.valueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;
using System.ComponentModel.DataAnnotations;
using NormalApi.Properties;
namespace NormalApi.Models
{
    
    //[ValueProvider(typeof(StaticValueProviderFactory))]//这一句是自定义ValueProVider的关键
    public class Contact
    {
        [Required(ErrorMessageResourceName="Required",ErrorMessageResourceType=typeof(Resources))]
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}