﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NUte.Validation
{
    internal static class Validator
    {
        private sealed class ParameterInfo<TValue>
        {
            public string Name { get; set; }
            public TValue Value { get; set; }
        }

        public static void NotNull(Expression<Func<object>> parameter, Action<string, string, bool> exception)
        {
            NotNull<object>(parameter, exception);
        }

        public static void NotNullOrEmpty(Expression<Func<string>> parameter, Action<string, string, bool> exception)
        {
            var parameterInfo = NotNull(parameter, exception);

            if (string.IsNullOrEmpty(parameterInfo.Value) && exception != null)
            {
                exception.Invoke("The parameter value is empty.", parameterInfo.Name, false);
            }
        }

        public static void NotNullOrWhiteSpace(Expression<Func<string>> parameter, Action<string, string, bool> exception)
        {
            var parameterInfo = NotNull(parameter, exception);

            if (string.IsNullOrWhiteSpace(parameterInfo.Value) && exception != null)
            {
                exception.Invoke("The parameter value is whitespace.", parameterInfo.Name, false);
            }
        }

        public static void NotNullOrEmpty(Expression<Func<IEnumerable>> parameter, Action<string, string, bool> exception)
        {
            NotNullEmptyOrNullElements(parameter, false, true, exception);
        }

        public static void NotNullOrNullElements(Expression<Func<IEnumerable>> parameter, Action<string, string, bool> exception)
        {
            NotNullEmptyOrNullElements(parameter, true, false, exception);
        }

        public static void NotNullEmptyOrNullElements(Expression<Func<IEnumerable>> parameter, Action<string, string, bool> exception)
        {
            NotNullEmptyOrNullElements(parameter, false, false, exception);
        }

        public static void NotNullEmptyOrNullWhiteSpaceElements(Expression<Func<IEnumerable<string>>> parameter, Action<string, string, bool> exception)
        {
            var parameterInfo = NotNull(parameter, exception);

            ValidateElements(parameterInfo.Name, parameterInfo.Value, false, false, exception);

            if (parameterInfo.Value.Any(string.IsNullOrWhiteSpace) && exception != null)
            {
                exception.Invoke("The parameter value contains at least one whitespace element.", parameterInfo.Name, false);
            }
        }

        private static void NotNullEmptyOrNullElements(Expression<Func<IEnumerable>> parameter, bool allowEmpty, bool allowNullElements, Action<string, string, bool> exception)
        {
            var parameterInfo = NotNull(parameter, exception);

            ValidateElements(parameterInfo.Name, parameterInfo.Value, allowEmpty, allowNullElements, exception);
        }

        private static void ValidateElements(string parameterName, IEnumerable parameterValue, bool allowEmpty, bool allowNullElements, Action<string, string, bool> exception)
        {
            var collection = parameterValue.Cast<object>().ToList();

            if (!allowEmpty && !collection.Any() && exception != null)
            {
                exception.Invoke("The parameter value is empty.", parameterName, false);
            }

            if (!allowNullElements && collection.Any(item => item == null) && exception != null)
            {
                exception.Invoke("The parameter value contains at least one null element.", parameterName, false);
            }
        }

        private static ParameterInfo<TValue> NotNull<TValue>(Expression<Func<TValue>> parameter, Action<string, string, bool> exception)
        {
            var parameterInfo = GetParameterInfo(parameter);
            var value = parameterInfo.Value as object;

            if (value == null && exception != null)
            {
                exception.Invoke(null, parameterInfo.Name, true);
            }

            return parameterInfo;
        }

        private static ParameterInfo<TValue> GetParameterInfo<TValue>(Expression<Func<TValue>> parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", "Unable to evaluate parameter.");
            }

            // Get the parameter name and value
            var @delegate = parameter.Compile();

            return new ParameterInfo<TValue>
                {
                    Name = GetParameterName(parameter),
                    Value = @delegate.Invoke()
                };
        }

        private static string GetParameterName<TValue>(Expression<Func<TValue>> parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", "Unable to resolve parameter name.");
            }

            // Get the name from the expression member name
            var expression = parameter.Body as MemberExpression;

            if (expression == null)
            {
                throw new ArgumentException("Unable to resolve parameter name.", "parameter");
            }

            return expression.Member.Name;
        }
    }
}