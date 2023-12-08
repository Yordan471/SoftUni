using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportXmlPlayDto
    {
        [Required]
        [MaxLength(PlayTitleLengthMax)]
        [MinLength(PlayTitleLengthMin)]
        [XmlElement("Title")]
        public string Title { get; set; } = null!;

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; } = null!;

        [Required]
        [Range(PlayRatingMin, PlayRatingMax)]
        [XmlElement("Raiting")]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; } = null!;

        [Required]
        [MaxLength(PlayDescriptionLengthMax)]
        [XmlElement("Description")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(PlayScreenwriterLengthMax)]
        [MinLength(PlayScreenwriterLengthMin)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; } = null!;
    }
}
