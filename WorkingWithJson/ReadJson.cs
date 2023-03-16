using System.IO;
using Newtonsoft.Json;

namespace WorkingWithJson
{
    internal class ReadJson
    {
        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadDirectlyFromJsonFile<T>(string filePath) where T : new()
        {
            JsonSerializer serializer = new JsonSerializer();
            StreamReader sr = null;
            JsonReader reader = null;

            try
            {
                sr = new StreamReader(filePath);
                reader = new JsonTextReader(sr);
                {
                    return serializer.Deserialize<T>(reader);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (sr != null)
                    sr.Close();
            }
        }
    }
}
