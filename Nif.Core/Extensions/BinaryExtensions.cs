using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nif.Core.Extensions
{
    public static class BinaryExtensions
    {
        public static MemoryStream SerializeToMemory<T>(this T source) where T : class
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);

                return stream;
            }
        }

        public static T DeserializeFromMemory<T>(this MemoryStream source) where T : class
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            using (source)
            {
                source.Position = 0;
                var formatter = new BinaryFormatter();

                return (T)formatter.Deserialize(source);
            }
        }
    }
}