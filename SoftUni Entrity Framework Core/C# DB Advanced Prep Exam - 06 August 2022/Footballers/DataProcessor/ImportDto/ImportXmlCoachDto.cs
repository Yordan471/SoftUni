using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Footballers.Utilities.GlobalConstants;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportXmlCoachDto
    {
        [Required]
        [MinLength(CoachNameLenthMin)]
        [MaxLength(CoachNameLenthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; } = null!;

        [XmlArray("Footballers")]
        public ImportXmlFootballerDto[] Footballers { get; set; }
    }
}
