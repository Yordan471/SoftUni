using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static TeisterMask.Utilities.GlobalConstants;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportXmlProjectDto
    {
        [Required]
        [MaxLength(ProjectNameLengthMax)]
        [MinLength(ProjectNameLengthMin)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string? DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportXmlTaskDto[] Tasks { get; set; }
    }
}
