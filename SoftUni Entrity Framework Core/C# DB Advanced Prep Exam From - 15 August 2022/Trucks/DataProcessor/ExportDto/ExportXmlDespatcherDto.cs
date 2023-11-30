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

        public ExportXmlTruckDto[] Trucks { get; set; }
    }
}
