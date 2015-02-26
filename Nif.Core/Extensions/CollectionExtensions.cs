using System;
using System.Diagnostics.Contracts;

namespace Nif.Core.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Fisher-Yates Shuffle
        /// </summary>
        public static T[] Shuffle<T>(this T[] source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            var random = new Random();

            for (int i = 0, length = source.Length; i < length; i++)
            {
                var index = i + (int)(random.NextDouble() * (length - i));
                var value = source[index];
                source[index] = source[i];
                source[i] = value;
            }

            return source;
        }
    }
}