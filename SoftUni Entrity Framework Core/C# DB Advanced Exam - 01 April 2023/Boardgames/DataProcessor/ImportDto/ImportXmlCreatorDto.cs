using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportXmlCreatorDto
    {       
        [Required]
        [MinLength(CreatorNameLengthMin)]
        [MaxLength(CreatorNameLengthMax)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(CreatorNameLengthMin)]
        [MaxLength(CreatorNameLengthMax)]
        [XmlElement("LastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public virtual ImportXmlBoardgameDto[] Boardgames { get; set; }
    }
}
