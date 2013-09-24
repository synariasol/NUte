using System;

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
    }
}