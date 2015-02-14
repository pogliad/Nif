using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Nif.Extensions
{
    public static class CollectionExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return Task.Run(() => source.ToList());
        }

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