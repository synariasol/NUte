using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace NUte.Testing.UnitTests
{
    public sealed class ObjectExtensionsFixture
    {
        public sealed class ToDictionaryMethod
        {
            private static IDictionary<string, object> _result;

            [Subject(typeof(ObjectExtensions), "ToDictionary")]
            public sealed class when_invoked_with_a_null_values_object
            {
                private Because of = () => _result = ObjectExtensions.ToDictionary(null);
                private It should_return_an_empty_dictionary = () => _result.ShouldBeEmpty();
            }

            [Subject(typeof(ObjectExtensions), "ToDictionary")]
            public sealed class when_invoked_with_a_values_object
            {
                private Because of = () => _result = ObjectExtensions.ToDictionary(new { prop1 = "Test", prop2 = 100 });
                private It should_return_a_properties_dictionary = () => _result.ShouldContain(
                    new KeyValuePair<string, object>("prop1", "Test"),
                    new KeyValuePair<string, object>("prop2", 100));
            }
        }
    }
}