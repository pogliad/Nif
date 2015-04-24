using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nif.Core.Extensions
{
    public static class XmlExtensions
    {
        public static string ToXml<T>(this T source) where T : class
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNull());

            using (var stream = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(stream, Encoding.Unicode) { Formatting = Formatting.None })
                {
                    var serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(writer, source);
                    var result = writer.BaseStream as MemoryStream;

                    return result != null ? Encoding.Unicode.GetString(result.ToArray()) : null;
                }
            }
        }

        public static T FromXml<T>(this string source) where T : class
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());

            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(source)))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(stream);
            }
        }
    }
}