using System;
using System.Diagnostics.Contracts;
using System.IO;
using Nif.Core.Extensions;

namespace Nif.Converters.StreamConverter
{
    public static class StreamConverter
    {
        public static byte[] Convert(Stream stream)
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