using System;
using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;
using NUte.Validation;

namespace NUte.Testing.UnitTests.Validation
{
    public sealed class VerifyFixture
    {
        public sealed class NotNullMethod
        {
            [Subject(typeof(Verify), "NotNull")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<object>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNull(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNull")]
            public sealed class when_invoked_with_an_object
                : ValidationFixtureBase<object>
            {
                private Establish context = () => Value = new object();
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNull(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotDefaultMethod
        {
            [Subject(typeof(Verify), "NotDefault")]
            public sealed class when_invoked_with_a_default_int
                : ValidationFixtureBase<int>
            {
                private Establish context = () => Value = default(int);
                private Because of = () => Exception = Catch.Exception(() => Verify.NotDefault(() => Value, "Test Message"));
                private It should_throw_anInvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotDefault")]
            public sealed class when_invoked_with_a_non_default_int
                : ValidationFixtureBase<int>
            {
                private Establish context = () => Value = 10;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotDefault(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullOrEmptyMethod_String
        {
            [Subject(typeof(Verify), "NotNullOrEmpty<string>")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrEmpty<string>")]
            public sealed class when_invoked_with_an_empty_string
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = string.Empty;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrEmpty<string>")]
            public sealed class when_invoked_with_a_string
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = "Test";
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullOrWhiteSpaceMethod
        {
            [Subject(typeof(Verify), "NotNullOrWhiteSpace")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrWhiteSpace(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrWhiteSpace")]
            public sealed class when_invoked_with_a_whitespace_string
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = "   ";
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrWhiteSpace(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrWhiteSpace")]
            public sealed class when_invoked_with_a_string
                : ValidationFixtureBase<string>
            {
                private Establish context = () => Value = "Test";
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrWhiteSpace(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullOrEmptyMethod_Enumerable
        {
            [Subject(typeof(Verify), "NotNullOrEmpty<IEnumerable>")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrEmpty<IEnumerable>")]
            public sealed class when_invoked_with_an_empty_IEnumerable
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new string[0];
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrEmpty<IEnumerable>")]
            public sealed class when_invoked_with_an_IEnumerable
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new[] { "Test1", "Test2" };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrEmpty(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullOrNullElementsMethod
        {
            [Subject(typeof(Verify), "NotNullOrNullElements")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrNullElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrNullElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_null_elements
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new[] { "Test", null };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrNullElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullOrNullElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_non_null_elements
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new[] { "Test1", "Test2" };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullOrNullElements(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullEmptyOrNullElementsMethod
        {
            [Subject(typeof(Verify), "NotNullEmptyOrNullElements")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullElements")]
            public sealed class when_invoked_with_an_empty_IEnumerable
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new string[0];
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_null_elements
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new[] { "Test", null };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_non_null_elements
                : ValidationFixtureBase<IEnumerable>
            {
                private Establish context = () => Value = new[] { "Test1", "Test2" };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullElements(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class NotNullEmptyOrNullWhiteSpaceElementsMethod
        {
            [Subject(typeof(Verify), "NotNullEmptyOrNullWhiteSpaceElements")]
            public sealed class when_invoked_with_null
                : ValidationFixtureBase<IEnumerable<string>>
            {
                private Establish context = () => Value = null;
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullWhiteSpaceElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullWhiteSpaceElements")]
            public sealed class when_invoked_with_an_empty_IEnumerable
                : ValidationFixtureBase<IEnumerable<string>>
            {
                private Establish context = () => Value = new List<string>();
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullWhiteSpaceElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullWhiteSpaceElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_null_elements
                : ValidationFixtureBase<IEnumerable<string>>
            {
                private Establish context = () => Value = new List<string> { "Test", null };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullWhiteSpaceElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullWhiteSpaceElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_whitespace_elements
                : ValidationFixtureBase<IEnumerable<string>>
            {
                private Establish context = () => Value = new List<string> { "Test", "     " };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullWhiteSpaceElements(() => Value, "Test Message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test Message");
            }

            [Subject(typeof(Verify), "NotNullEmptyOrNullWhiteSpaceElements")]
            public sealed class when_invoked_with_an_IEnumerable_containing_non_null_and_non_whitespace_elements
                : ValidationFixtureBase<IEnumerable<string>>
            {
                private Establish context = () => Value = new[] { "Test1", "Test2" };
                private Because of = () => Exception = Catch.Exception(() => Verify.NotNullEmptyOrNullWhiteSpaceElements(() => Value, "Test Message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class IsTrueMethod
        {
            [Subject(typeof(Verify), "IsTrue")]
            public sealed class when_invoked_with_a_false_condition
                : ValidationFixtureBase<Func<bool>>
            {
                private Establish context = () => Value = () => false;
                private Because of = () => Exception = Catch.Exception(() => Verify.IsTrue(Value, "Test message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test message");
            }

            [Subject(typeof(Verify), "IsTrue")]
            public sealed class when_invoked_with_a_true_condition
                : ValidationFixtureBase<Func<bool>>
            {
                private Establish context = () => Value = () => true;
                private Because of = () => Exception = Catch.Exception(() => Verify.IsTrue(Value, "Test message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }

        public sealed class IsFalseMethod
        {
            [Subject(typeof(Verify), "IsFalse")]
            public sealed class when_invoked_with_a_true_condition
                : ValidationFixtureBase<Func<bool>>
            {
                private Establish context = () => Value = () => true;
                private Because of = () => Exception = Catch.Exception(() => Verify.IsFalse(Value, "Test message"));
                private It should_throw_an_InvalidOperationException = () => Exception.ShouldBeOfType<InvalidOperationException>();
                private It should_set_the_exception_message = () => VerifyExceptionMessage("Test message");
            }

            [Subject(typeof(Verify), "IsFalse")]
            public sealed class when_invoked_with_a_false_condition
                : ValidationFixtureBase<Func<bool>>
            {
                private Establish context = () => Value = () => false;
                private Because of = () => Exception = Catch.Exception(() => Verify.IsFalse(Value, "Test message"));
                private It should_not_throw_an_exception = () => Exception.ShouldBeNull();
            }
        }
    }
}