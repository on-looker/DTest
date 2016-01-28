using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace NormalApi.Binders
{
    [ValueProvider(typeof(HttpHeaderValueProvider))]
    public class CommonHeader
    {
        public string Connection{get;set;}
        public string CacheControl{get;set;}

       public string Host{get;set;}

        public IEnumerable<string> Accept{get;set;}

        public IEnumerable<string> AcceptEncoding{get;set;}
        public IEnumerable<string> AcceptLanguage{get;set;}

        public  IEnumerable<string> UserAgent{get;set;}
    }
}