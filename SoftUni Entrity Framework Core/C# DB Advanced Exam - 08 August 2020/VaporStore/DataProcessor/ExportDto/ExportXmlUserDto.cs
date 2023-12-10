using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("User")]
    public class ExportXmlUserDto
    {
        [XmlAttribute("username")]
        public string username { get; set; }

        [XmlArray("Purchases")]
        public ExportXmlPurchaseDto[] Purchases { get; set; }
    }
}
