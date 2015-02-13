using System;
using System.Diagnostics.Contracts;
using System.IO;
using Newtonsoft.Json;
using Nif.Extensions;

namespace Nif.Converters.JsonConverter
{
    public static class JsonConverter
    {
        public static string Serialize(object obj)
        {
            Contract.Requires<ArgumentNullException>(obj.IsNotNull());

            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        public static void SerializeToFile(object obj, string filePath)
        {
            Contract.Requires<ArgumentNullException>(obj != null);
            Contract.Requires<ArgumentNullException>(filePath.IsNotNullOrEmpty());

            var json = Serialize(obj);
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var writer = new StreamWriter(fs);
                writer.WriteLine(json);
                writer.Flush();
                writer.Close();
            }
        }

        public static T Deserialize<T>(string json)
        {
            Contract.Requires<ArgumentNullException>(json.IsNotNullOrEmpty());

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}