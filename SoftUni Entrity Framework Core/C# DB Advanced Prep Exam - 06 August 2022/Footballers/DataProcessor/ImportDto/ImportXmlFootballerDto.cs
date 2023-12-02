using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Footballers.Utilities.GlobalConstants;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportXmlFootballerDto
    {
        [Required]
        [MinLength(FootballerNameLengthMin)]
        [MaxLength(FootballerNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; } = null!;

        [Required]
        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [Required]
        [XmlElement("PositionType")]
        [Range(0, 3)]
        public int PositionType { get; set; }     
    }
}
