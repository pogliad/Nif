using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using Nif.Core.Extensions;

namespace Nif.Core.Utilities
{
    public static class EnumUtility
    {
        public static string GetEnumeratorDescription(Enum source)
        {
            var field = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }

        public static IEnumerable<string> GetEnumeratorDescriptions<TEnum>()
        {
            Contract.Requires<ArgumentException>(typeof(TEnum).IsEnum);

            return from Enum value in Enum.GetValues(typeof(TEnum))
                   select GetEnumeratorDescription(value);
        }

        public static IEnumerable<KeyValuePair<string, string>> GetEnumeratorNamesAndDescriptions<TEnum>()
        {
            Contract.Requires<ArgumentException>(typeof(TEnum).IsEnum);

            return from object value in Enum.GetValues(typeof(TEnum))
                   select value.ToString()
                       into name
                       let desciption = GetEnumeratorDescription((Enum)Enum.Parse(typeof(TEnum), name))
                       select new KeyValuePair<string, string>(name, desciption);
        }

        public static TEnum GetEnumeratorFromValue<TEnum>(string value)
        {
            Contract.Requires<ArgumentException>(typeof(TEnum).IsEnum);
            Contract.Requires<ArgumentNullException>(value.IsNotNullOrEmpty());

            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static TEnum GetValueFromDescription<TEnum>(string description)
        {
            Contract.Requires<ArgumentException>(typeof(TEnum).IsEnum);
            Contract.Requires<ArgumentNullException>(description.IsNotNullOrEmpty());

            var type = typeof(TEnum);

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (TEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (TEnum)field.GetValue(null);
                }
            }

            return default(TEnum);
        }
    }
}