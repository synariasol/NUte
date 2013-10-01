using System;
using System.Linq;
using System.Reflection;
using NUte.Validation;

namespace NUte
{
    public static class EnumExtensions
    {
        public static string GetEnumData<TEnum>(this Type enumType, TEnum value)
            where TEnum : struct
        {
            if (enumType != null)
            {
                Argument.Verify(() => enumType == typeof (TEnum), "The specified enumeration type is invalid.");
            }

            return GetEnumData(enumType, (object) value);
        }

        public static string GetEnumData(this Type enumType, object value)
        {
            Argument.NotNull(() => enumType);
            Argument.NotNull(() => value);

            Argument.Verify(() => enumType.IsEnum, "The specified type is not an enumeration.");

            var valueName = value.ToString();

            return (from member in enumType.GetMember(valueName)
                    let attribute = member.GetCustomAttribute<EnumDataAttribute>()
                    where attribute != null
                    select attribute.Data).SingleOrDefault();
        }

        public static TEnum? GetEnumFromData<TEnum>(this Type enumType, string data)
            where TEnum : struct
        {
            var value = GetEnumFromData(enumType, data);

            return value == null
                       ? (TEnum?) null
                       : (TEnum) value;
        }

        public static object GetEnumFromData(this Type enumType, string data)
        {
            Argument.NotNull(() => enumType);
            Argument.NotNull(() => data);

            Argument.Verify(() => enumType.IsEnum, "The specified type is not an enumeration.");
            
            return (from field in enumType.GetFields()
                    let attribute = field.GetCustomAttribute<EnumDataAttribute>()
                    where attribute != null && attribute.Data.IsEqual(data) 
                    select field.GetValue(null)).SingleOrDefault();
        }
    }
}