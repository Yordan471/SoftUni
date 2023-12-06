using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportXmlPharmacyDto
    {
        [Required]
        [MinLength(PharmacyNameLengthMin)]
        [MaxLength(PharmacyNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PharmacyPhoneNumberLength)]
        [MinLength(PharmacyPhoneNumberLength)]
        [RegularExpression(PharmacyPhoneNumberRegularExpressionValidation)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; }

        [XmlArray("Medicines")]
        public ImportXmlMedicineDto[] Medicines { get; set; }
    }
}
