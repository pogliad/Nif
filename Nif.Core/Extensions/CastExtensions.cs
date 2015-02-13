using System;
using System.Diagnostics.Contracts;

namespace Nif.Core.Extensions
{
    public static class CastExtensions
    {
        public static T TryCast<T>(this object source, out bool wasCastedSuccessful)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            wasCastedSuccessful = false;

            if (source is T)
            {
                wasCastedSuccessful = true;

                return (T)source;
            }

            return default(T);
        }

        public static bool TryCast<T>(this object source, out T castedObject)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            if (source is T)
            {
                castedObject = (T)source;

                return true;
            }

            castedObject = default(T);

            return false;
        }
    }
}