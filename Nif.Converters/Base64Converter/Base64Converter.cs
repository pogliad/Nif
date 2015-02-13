using System;
using System.Diagnostics.Contracts;
using Nif.Core.Extensions;

namespace Nif.Converters.Base64Converter
{
    public static class Base64Converter
    {
        public static string Encode(byte[] source)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            return Convert.ToBase64String(source);
        }

        public static byte[] Decode(string source)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());

            return Convert.FromBase64String(source);
        }
    }
}