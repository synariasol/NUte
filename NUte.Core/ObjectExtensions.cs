using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NUte
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object values)
        {
            if (values == null)
            {
                return new Dictionary<string, object>();
            }

            return (from PropertyDescriptor property in TypeDescriptor.GetProperties(values)
                    select property).ToDictionary(property => property.Name, property => property.GetValue(values));
        }
    }
}