using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Nif.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            var random = new Random();

            return source.OrderBy(x => (random.Next()));
        }        
    }
}