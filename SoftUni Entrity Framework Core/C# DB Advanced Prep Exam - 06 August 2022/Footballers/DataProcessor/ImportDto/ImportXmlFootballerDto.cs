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
        public DateTime ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public DateTime ContractEndDate { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        [XmlElement("PositionType")]
        public PositionType PositionType { get; set; }     
    }
}
