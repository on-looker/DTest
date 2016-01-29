using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.ValueProviders;

namespace NormalApi.ValueProviders
{
    public class DicitonaryValueProvider:IValueProvider
    {
        public IDictionary<string, object> values { get; private set; }
        public bool ContainsPrefix(string prefix)
        {
           return values.Where(v => v.Key.Contains(prefix)).Count() > 0;
                
        }
        public DicitonaryValueProvider(IDictionary<string,object> vas)
        {
            values = vas;
        }

        public ValueProviderResult GetValue(string key)
        {
            object value;
            if (values.TryGetValue(key,out value))
            {
                return new ValueProviderResult(value, value.ToString(), CultureInfo.InvariantCulture);
            }
            return null;
        }
    }
}