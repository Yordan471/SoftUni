using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportXmlCastDto
    {
        [Required]
        [MaxLength(CastFullNameLengthMax)]
        [MinLength(CastFullNameLengthMin)]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("IsMainCharacter")]
        public string IsMainCharacter { get; set; } = null!;

        [Required]
        [RegularExpression(CastPhoneNumberRegularExpressionValidation)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
