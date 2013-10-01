using Machine.Specifications;

namespace NUte.Testing.UnitTests.Validation
{
    public static class ValidationMessages
    {
        public const string EmptyMessage = "The parameter value is empty.\r\nParameter name: {0}";
        public const string WhiteSpaceMessage = "The parameter value is whitespace.\r\nParameter name: {0}";
        public const string NullElementsMessage = "The parameter value contains at least one null element.\r\nParameter name: {0}";
        public const string WhiteSpaceElementsMessage = "The parameter value contains at least one whitespace element.\r\nParameter name: {0}";

        public static void VerifyMessage(string message, string format, params object[] arguments)
        {
            var formattedMessage = string.Format(format, arguments);

            message.ShouldBeEqualIgnoringCase(formattedMessage);
        }
    }
}