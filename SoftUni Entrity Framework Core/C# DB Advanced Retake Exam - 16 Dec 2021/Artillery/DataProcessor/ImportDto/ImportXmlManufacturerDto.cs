using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportXmlManufacturerDto
    {
        [Required]
        [MaxLength(ManufacturerNameLengthMax)]
        [MinLength(ManufacturerNameLengthMin)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(ManufacturerFoundedLengthMax)]
        [MinLength(ManufacturerFoundedLengthMin)]
        [XmlElement("Founded")]
        public string Founded { get; set; } = null!;
    }
}
