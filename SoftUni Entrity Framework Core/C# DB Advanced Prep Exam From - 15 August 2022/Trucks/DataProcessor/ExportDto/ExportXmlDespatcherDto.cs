using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportXmlDespatcherDto
    {

        [XmlElement("DespatcherName")]
        public string Name { get; set; } = null!;

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }
    }
}
