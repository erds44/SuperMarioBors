using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SuperMarioBros.Utility
{
    public class XMLUtility
    {
        /// <summary>
        /// Read from a file, return a list containing given type elements.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="path">File path</param>
        /// <returns>A list of the content of file.</returns>
        public static List<T> XMLReader<T>(string path)
        {   
            List<T> xmlcontent = new List<T>();
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                xmlcontent = (List<T>)serializer.Deserialize(reader);
            }
            return xmlcontent;
        }
        /// <summary>
        /// Write a list of type T elements to a file.
        /// </summary>
        /// <typeparam name="T">type parameter</typeparam>
        /// <param name="path">file path</param>
        /// <param name="list">the path that the file will write to</param>
        public static void XMLWriter<T>(string path, List<T> list)
        {
            using (var writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(writer, list);
            }
        }
    }
}
