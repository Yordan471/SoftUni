using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportXmlCreatorDto
    {       
        public ImportXmlCreatorDto() 
        {
            Boardgames = new HashSet<ImportXmlBoardgameDto>();
        }

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
        public virtual ICollection<ImportXmlBoardgameDto> Boardgames { get; set; }
    }
}
