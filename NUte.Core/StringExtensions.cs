using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using NUte.Validation;

namespace NUte
{
    public static class StringExtensions
    {
        public static bool IsEqual(this string source, string value, bool ignoreCase = true)
        {
            if (source == null)
            {
                return value == null;
            }

            return ignoreCase
                       ? source.Equals(value, StringComparison.OrdinalIgnoreCase)
                       : source.Equals(value);
        }

        public static string Format(this string pattern, object values)
        {
            if (pattern != null)
            {
                Argument.NotNull(() => values);

                var tokensDictionary = new Dictionary<string, string>();

                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(values))
                {
                    var propertyValue = propertyDescriptor.GetValue(values);
                    var value = propertyValue == null
                                    ? string.Empty
                                    : propertyValue.ToString();

                    tokensDictionary.Add(propertyDescriptor.Name, value);
                }

                return pattern.Format(tokensDictionary);
            }

            return null;
        }

        public static string Format(this string pattern, IDictionary<string, string> values)
        {
            if (pattern != null)
            {
                Argument.NotNull(() => values);

                var result = pattern;

                foreach (var key in values.Keys)
                {
                    var placeholder = string.Concat(@"\{", key, @"\}");

                    result = Regex.Replace(result, placeholder, values[key]);
                }

                return result;
            }

            return null;
        }
    }
}