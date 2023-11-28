using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.Utilities
{
    public  class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), root);

            StringReader reader = new StringReader(inputXml);

            T users = (T)xmlSerializer.Deserialize(reader);

            return users;
        }

        public string Serializer<T>(T obj, string rootName)
        {
            StringBuilder sb = new();

            XmlRootAttribute xmlRoot = new(rootName);
            XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

            XmlSerializerNamespaces xmlSerializerNamespaces = new();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
