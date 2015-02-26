using System;
using System.Diagnostics.Contracts;

namespace Nif.Core.Extensions
{
    public static class StringExtensions
    {
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

        public static bool NotContains(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            return !source.Contains(seekValue);
        }

        public static bool ContainsCaseInsensitive(this string source, string seekValue)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());
            Contract.Requires<ArgumentNullException>(seekValue.IsNotNullOrEmpty());

            var results = source.IndexOf(seekValue, StringComparison.CurrentCultureIgnoreCase);

            return results != -1;
        }
    }
}