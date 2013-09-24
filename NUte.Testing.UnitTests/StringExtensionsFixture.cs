using Machine.Specifications;

namespace NUte.Testing.UnitTests
{
    public sealed class StringExtensionsFixture
    {
        public sealed class IsEqualMethod
        {
            private static bool _result;

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_null_source_and_a_null_value
            {
                private Because of = () => _result = StringExtensions.IsEqual(null, null);
                private It should_return_true = () => _result.ShouldBeTrue();
            }

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_null_source_and_a_non_null_value
            {
                private Because of = () => _result = StringExtensions.IsEqual(null, "Value");
                private It should_return_false = () => _result.ShouldBeFalse();
            }

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_non_null_source_and_a_null_value
            {
                private Because of = () => _result = StringExtensions.IsEqual("Source", null);
                private It should_return_false = () => _result.ShouldBeFalse();
            }

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_case_insensitive_matching_source_and_value
            {
                private Because of = () => _result = StringExtensions.IsEqual("Match", "match");
                private It should_return_true = () => _result.ShouldBeTrue();
            }

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_case_sensitive_matching_source_and_value
            {
                private Because of = () => _result = StringExtensions.IsEqual("Match", "match", false);
                private It should_return_false = () => _result.ShouldBeFalse();
            }

            [Subject(typeof(StringExtensions), "IsEqual")]
            public sealed class when_invoked_with_a_non_matching_source_and_value
            {
                private Because of = () => _result = StringExtensions.IsEqual("Source", "Value");
                private It should_return_false = () => _result.ShouldBeFalse();
            }
        }
    }
}