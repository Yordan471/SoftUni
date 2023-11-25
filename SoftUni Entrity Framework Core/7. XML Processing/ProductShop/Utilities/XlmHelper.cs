using ProductShop.DTOs.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XlmHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), root);

            StringReader reader = new StringReader(inputXml);

            T users = (T)xmlSerializer.Deserialize(reader);

            return users;
        }
    }
}
