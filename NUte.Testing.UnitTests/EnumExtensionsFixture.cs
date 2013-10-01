using System;
using Machine.Specifications;

namespace NUte.Testing.UnitTests
{
    public sealed class EnumExtensionsFixture
    {
        private enum EnumValues
        {
            Value1,

            [EnumData("Data")]
            Value2
        }

        private static readonly Type EnumType = typeof(EnumValues);

        public sealed class GetEnumDataMethod_TEnum
        {
            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_an_invalid_enumType
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(typeof(int), 123));
                private It should_throw_an_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();
                private It should_set_the_exception_message = () => _exception.Message.ShouldBeEqualIgnoringCase("The specified type is not an enumeration.");
            }

            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_a_null_enumType
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(null, EnumValues.Value1));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_a_null_value
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(EnumType, null));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_a_non_enum_type
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(typeof(int), 123));
                private It should_throw_an_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();
                private It should_set_the_exception_message = () => _exception.Message.ShouldBeEqualIgnoringCase("The specified type is not an enumeration.");
            }

            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_a_value_without_data
            {
                private static string _data;

                private Because of = () => _data = EnumExtensions.GetEnumData(EnumType, EnumValues.Value1);
                private It should_return_null = () => _data.ShouldBeNull();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData<TEnum>")]
            public sealed class when_invoked_with_a_value_with_data
            {
                private static string _data;

                private Because of = () => _data = EnumExtensions.GetEnumData(EnumType, EnumValues.Value2);
                private It should_return_data = () => _data.ShouldEqual("Data");
            }
        }

        public sealed class GetEnumDataMethod
        {
            [Subject(typeof(EnumExtensions), "GetEnumData")]
            public sealed class when_invoked_with_a_null_enumType
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(null, (object) EnumValues.Value1));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData")]
            public sealed class when_invoked_with_a_null_value
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(EnumType, null));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData")]
            public sealed class when_invoked_with_a_non_enum_type
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumData(typeof(int), (object)EnumValues.Value1));
                private It should_throw_an_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();
                private It should_set_the_exception_message = () => _exception.Message.ShouldBeEqualIgnoringCase("The specified type is not an enumeration.");
            }

            [Subject(typeof(EnumExtensions), "GetEnumData")]
            public sealed class when_invoked_with_a_value_without_data
            {
                private static string _data;

                private Because of = () => _data = EnumExtensions.GetEnumData(EnumType, (object) EnumValues.Value1);
                private It should_return_null = () => _data.ShouldBeNull();
            }

            [Subject(typeof(EnumExtensions), "GetEnumData")]
            public sealed class when_invoked_with_a_value_with_data
            {
                private static string _data;

                private Because of = () => _data = EnumExtensions.GetEnumData(EnumType, (object) EnumValues.Value2);
                private It should_return_data = () => _data.ShouldEqual("Data");
            }
        }

        public sealed class GetEnumFromDataMethod_TEnum
        {
            [Subject(typeof(EnumExtensions), "GetEnumFromData<TEnum>")]
            public sealed class when_invoked_with_a_null_enumType
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData<EnumValues>(null, "Data"));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData<TEnum>")]
            public sealed class when_invoked_with_a_null_data
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData<EnumValues>(EnumType, null));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData<TEnum>")]
            public sealed class when_invoked_with_a_non_enum_type
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData<EnumValues>(typeof(int), "Data"));
                private It should_throw_an_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();
                private It should_set_the_exception_message = () => _exception.Message.ShouldBeEqualIgnoringCase("The specified type is not an enumeration.");
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData<TEnum>")]
            public sealed class when_invoked_with_a_value_without_data
            {
                private static EnumValues? _value;

                private Because of = () => _value = EnumExtensions.GetEnumFromData<EnumValues>(EnumType, "Test");
                private It should_return_null = () => _value.ShouldBeNull();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData<TEnum>")]
            public sealed class when_invoked_with_a_value_with_data
            {
                private static EnumValues? _value;

                private Because of = () => _value = EnumExtensions.GetEnumFromData<EnumValues>(EnumType, "Data");
                private It should_return_data = () => _value.ShouldEqual(EnumValues.Value2);
            }
        }

        public sealed class GetEnumFromDataMethod
        {
            [Subject(typeof(EnumExtensions), "GetEnumFromData")]
            public sealed class when_invoked_with_a_null_enumType
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData(null, "Data"));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData")]
            public sealed class when_invoked_with_a_null_data
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData(EnumType, null));
                private It should_throw_an_ArgumentNullException = () => _exception.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData")]
            public sealed class when_invoked_with_a_non_enum_type
            {
                private static Exception _exception;

                private Because of = () => _exception = Catch.Exception(() => EnumExtensions.GetEnumFromData(typeof(int), "Data"));
                private It should_throw_an_ArgumentException = () => _exception.ShouldBeOfType<ArgumentException>();
                private It should_set_the_exception_message = () => _exception.Message.ShouldBeEqualIgnoringCase("The specified type is not an enumeration.");
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData")]
            public sealed class when_invoked_with_a_value_without_data
            {
                private static object _value;

                private Because of = () => _value = EnumExtensions.GetEnumFromData(EnumType, "Test");
                private It should_return_null = () => _value.ShouldBeNull();
            }

            [Subject(typeof(EnumExtensions), "GetEnumFromData")]
            public sealed class when_invoked_with_a_value_with_data
            {
                private static object _value;

                private Because of = () => _value = EnumExtensions.GetEnumFromData(EnumType, "Data");
                private It should_return_data = () => _value.ShouldEqual(EnumValues.Value2);
            }
        }
    }
}