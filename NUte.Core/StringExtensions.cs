using System;
using System.Collections.Generic;
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

                var dictionary = values.ToDictionary();
                var tokensDictionary = new Dictionary<string, string>();

                foreach (var item in dictionary)
                {
                    var value = item.Value == null ? null : item.Value.ToString();

                    tokensDictionary.Add(item.Key, value);
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
                    
                    result = Regex.Replace(result, placeholder, values[key] ?? string.Empty);
                }

                return result;
            }

            return null;
        }
    }
}