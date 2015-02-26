using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Nif.Core.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ToBytes(this Stream stream)
        {
            Contract.Requires<ArgumentNullException>(stream.IsNotNull());

            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);

                return ms.ToArray();
            }
        }
    }
}