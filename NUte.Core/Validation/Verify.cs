using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NUte.Validation
{
    public static class Verify
    {
        public static void NotNull(Expression<Func<object>> argument, string message)
        {
            Validator.NotNull(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotDefault<TType>(Expression<Func<TType>> argument, string message)
        {
            Validator.NotDefault(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullOrEmpty(Expression<Func<string>> argument, string message)
        {
            Validator.NotNullOrEmpty(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullOrWhiteSpace(Expression<Func<string>> argument, string message)
        {
            Validator.NotNullOrWhiteSpace(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullOrEmpty(Expression<Func<IEnumerable>> argument, string message)
        {
            Validator.NotNullOrEmpty(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullOrNullElements(Expression<Func<IEnumerable>> argument, string message)
        {
            Validator.NotNullOrNullElements(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullEmptyOrNullElements(Expression<Func<IEnumerable>> argument, string message)
        {
            Validator.NotNullEmptyOrNullElements(argument, (m, p, n) => ThrowException(message ?? m));
        }

        public static void NotNullEmptyOrNullWhiteSpaceElements(Expression<Func<IEnumerable<string>>> argument, string message)
        {
            Validator.NotNullEmptyOrNullWhiteSpaceElements(argument, (m, a, n) => ThrowException(message ?? m));
        }

        public static void IsTrue(Func<bool> condition, string message)
        {
            if (condition == null)
            {
                return;
            }

            var valid = condition.Invoke();

            if (!valid)
            {
                ThrowException(message);
            }
        }

        public static void IsFalse(Func<bool> condition, string message)
        {
            if (condition == null)
            {
                return;
            }

            var valid = condition.Invoke();

            if (valid)
            {
                ThrowException(message);
            }
        }

        private static void ThrowException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}