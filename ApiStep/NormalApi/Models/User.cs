using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace NormalApi.Models
{
    // [TypeConverter(typeof(UserTypeConverter))]
    [ValueProvider(typeof(QueryStringValueProviderFactory))]
    public class User : IValidatableObject
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name字段是必须的", new string[] { "Name" });
            }
        }
    }

    public class UserTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                var splits = (value as string).Split(',');
                User user = new User();
                user.Name = splits.First();
                user.Age = int.Parse(splits.Last());
                return user;
            }
            else
            {
                throw new FormatException("只支持从string到User的转化!");
            }
        }

    }
}