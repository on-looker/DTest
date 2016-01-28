﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace NormalApi.valueProvider
{
    public class StaticValueProviderFactory : ValueProviderFactory
    {
        private static List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
        public override IValueProvider GetValueProvider(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return new NameValuePairsValueProvider(values, CultureInfo.InvariantCulture);
        }
        public static void Clear()
        {
            values.Clear();
        }
        public static void Add(string name,string value)
        {
            values.Add(new KeyValuePair<string,string>(name,value));
        }

    }
}