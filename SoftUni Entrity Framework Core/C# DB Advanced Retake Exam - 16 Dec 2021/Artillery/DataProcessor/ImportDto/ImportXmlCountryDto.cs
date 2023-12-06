using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportXmlCountryDto
    {
        [Required]
        [MaxLength(CountryNameLengthMax)]
        [MinLength(CountryNameLengthMin)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(CountryArmySizeMin, CountryArmySizeMax)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}
