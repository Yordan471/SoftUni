using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;
using static Trucks.Utilities.GlobalConstants;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportXmlDespatcherDto
    {
        [Required]
        [MinLength(DespatcherNameLengthMin)]
        [MaxLength(DespatcherNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string? Position { get; set; }

        [XmlArray("Trucks")]
        public virtual ImportXmlTruckDto[] Trucks { get; set; }
    }
}
