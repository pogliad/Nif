using System;
using System.Diagnostics.Contracts;

namespace Nif.Core.Extensions
{
    public static class CastExtensions
    {
        public static bool TryCast<T>(this object source, out T target)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            if (source is T)
            {
                target = (T)source;

                return true;
            }

            target = default(T);

            return false;
        }
    }
}