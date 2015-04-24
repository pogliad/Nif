using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Nif.Core.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ToBytes(this Stream source)
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            using (var stream = new MemoryStream())
            {
                source.CopyTo(stream);

                return stream.ToArray();
            }
        }
    }
}