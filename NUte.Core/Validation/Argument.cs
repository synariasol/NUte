﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NUte.Validation
{
    public static class Argument
    {
        public static void NotNull(Expression<Func<object>> argument, string message = null)
        {
            Validator.NotNull(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullOrEmpty(Expression<Func<string>> argument, string message = null)
        {
            Validator.NotNullOrEmpty(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullOrWhiteSpace(Expression<Func<string>> argument, string message = null)
        {
            Validator.NotNullOrWhiteSpace(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullOrEmpty(Expression<Func<IEnumerable>> argument, string message = null)
        {
            Validator.NotNullOrEmpty(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullOrNullElements(Expression<Func<IEnumerable>> argument, string message = null)
        {
            Validator.NotNullOrNullElements(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullEmptyOrNullElements(Expression<Func<IEnumerable>> argument, string message = null)
        {
            Validator.NotNullEmptyOrNullElements(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void NotNullEmptyOrNullWhiteSpaceElements(Expression<Func<IEnumerable<string>>> argument, string message = null)
        {
            Validator.NotNullEmptyOrNullWhiteSpaceElements(argument, (m, a, n) => ThrowException(message ?? m, a, n));
        }

        public static void Verify(Func<bool> condition, string message)
        {
            var valid = condition != null && condition.Invoke();

            if (!valid)
            {
                ThrowException(message, null, false);
            }
        }

        private static void ThrowException(string message, string argumentName, bool isNull)
        {
            if (isNull)
            {
                throw new ArgumentNullException(argumentName, message);
            }

            throw new ArgumentException(message, argumentName);            
        }
    }
}