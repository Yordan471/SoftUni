using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportXmlAddressesDto
    {
        [Required]
        [MinLength(AddressesStreetNameLengthMin)]
        [MaxLength(AddressesStreetNameLengthMax)]
        [XmlElement("StreetName")]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;

        [Required]
        [MinLength(AddressesCityNameLengthMin)]
        [MaxLength(AddressesCityNameLengthMax)]
        [XmlElement("City")]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(AddressesCountryNameLengthMin)]
        [MaxLength(AddressesCountryNameLengthMax)]
        [XmlElement("Country")]
        public string Country { get; set; } = null!;
    }
}
