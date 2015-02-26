﻿using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Nif.Core.Extensions
{   
    public static class XmlExtensions
    {
        public static string ToXml<T>(this T obj) where T : class
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(ms, Encoding.Unicode) { Formatting = Formatting.None })
                {
                    var serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(writer, obj);
                    var result = writer.BaseStream as MemoryStream;

                    return result != null ? Encoding.Unicode.GetString(result.ToArray()) : null;
                }
            }
        }

        public static T FromXml<T>(this string xml)
        {
            Contract.Requires<ArgumentNullException>(xml.IsNotNullOrEmpty());

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(ms);
            }
        }
    }
}