﻿using System;
using System.Diagnostics.Contracts;
using System.Security;

namespace Nif.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !String.IsNullOrEmpty(source);
        }

        public static bool EqualsCaseInsensitive(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            return source.Equals(seekValue, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool NotEqualsCaseInsensitive(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            return !source.EqualsCaseInsensitive(seekValue);
        }

        public static bool ContainsCaseInsensitive(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            var result = source.IndexOf(seekValue, StringComparison.CurrentCultureIgnoreCase);

            return result != -1;
        }

        public static bool NotContains(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            return !source.Contains(seekValue);
        }

        public static SecureString ToSecureString(this string source)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());

            var result = new SecureString();

            foreach (var @char in source)
            {
                result.AppendChar(@char);
            }

            return result;
        }
    }
}