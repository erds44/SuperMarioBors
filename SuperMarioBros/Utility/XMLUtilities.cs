using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperMarioBros.Utility
{
    public class XMLUtility
    {
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
