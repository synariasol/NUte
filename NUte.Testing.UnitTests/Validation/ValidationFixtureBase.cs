using System;
using Machine.Specifications;

namespace NUte.Testing.UnitTests.Validation
{
    public abstract class ValidationFixtureBase<TValue>
    {
        protected const string EmptyMessage = "The parameter value is empty.\r\nParameter name: Value";
        protected const string WhiteSpaceMessage = "The parameter value is whitespace.\r\nParameter name: Value";
        protected const string NullElementsMessage = "The parameter value contains at least one null element.\r\nParameter name: Value";
        protected const string WhiteSpaceElementsMessage = "The parameter value contains at least one whitespace element.\r\nParameter name: Value";

        protected static TValue Value;
        protected static Exception Exception;

        protected static void VerifyExceptionMessage(string message)
        {
            Exception.ShouldNotBeNull();
            Exception.Message.ShouldBeEqualIgnoringCase(message);
        }

        protected static void VerifyArgumentNullExceptionParamName()
        {
            var exception = Exception as ArgumentNullException;

            VerifyExceptionParamName(exception, e => exception.ParamName);
        }

        protected static void VerifyArgumentExceptionParamName()
        {
            var exception = Exception as ArgumentException;

            VerifyExceptionParamName(exception, e => exception.ParamName);
        }

        private static void VerifyExceptionParamName<TException>(TException exception, Func<TException, string> name)
            where TException : Exception
        {
            // Check the exception cast
            exception.ShouldNotBeNull();

            // Check the exception paramName value
            var paramName = name.Invoke(exception);

            paramName.ShouldBeEqualIgnoringCase("Value");
        }
    }
}