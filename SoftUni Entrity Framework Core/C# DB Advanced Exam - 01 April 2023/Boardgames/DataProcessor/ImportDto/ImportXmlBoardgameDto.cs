using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Utilities.GlobalConstraints;


namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportXmlBoardgameDto
    {
        [Required]
        [MinLength(BoardgameNameLengthMin)]
        [MaxLength(BoardgameNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(BoardgameRatingRangeMin, BoardgameRatingRangeMax)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [Range(BoardGameYearPublishedMin, BoardGameYearPublishedMax)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
