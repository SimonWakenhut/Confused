using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Confused
{
    /// <summary>
    ///     The "Parse"-class contains all necessary functions to open a .conf-file
    /// </summary>
    public static class Parse
    {
        /// <summary>
        ///     Parses a .conf-file from a string into a KeyValueStore
        /// </summary>
        /// <param name="conf">A string representing a .conf-file</param>
        public static KeyValueStore String(string conf)
        {
            var dictionary = new KeyValueStore();

            using (var reader = new StringReader(conf))
            {
                string line;
                KeyValue container = null;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Split('#')[0].Trim();

                    if (line.StartsWith('[') && line.EndsWith(']'))
                    {
                        var sectionName = line.TrimStart('[').TrimEnd(']');
                        container = new KeyValue();

                        dictionary.Add(sectionName, container);
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        var elements = line.Split('=');
                        container?.Add(elements[0].Trim(), elements[1].Trim());
                    }
                }
            }

            return dictionary;
        }

        /// <summary>
        ///     Parses a .conf-file from a file into a KeyValueStore
        /// </summary>
        /// <param name="path">A string representing a path to a .conf-file</param>
        public static KeyValueStore File(string path)
        {
            return String(System.IO.File.ReadAllText(path));
        }

        /// <summary>
        ///     A helper function to convert a string value to different types
        /// </summary>
        /// <param name="value">A string representing a value</param>
        public static T Value<T>(string value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        ///     A helper function to convert a string value into an array of the given type
        /// </summary>
        /// <param name="value">A string representing an array</param>
        public static T[] Array<T>(string value)
        {
            var elements = value.Split(',');
            var list = new List<T>();
            elements.ToList().ForEach(x => list.Add(Value<T>(x.Trim())));

            return list.ToArray<T>();
        }
    }
}