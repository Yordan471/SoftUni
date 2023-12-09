using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;
using static TeisterMask.Utilities.GlobalConstants;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportXmlTaskDto
    {
        [Required]
        [MaxLength(TaskNameLengthMax)]
        [MinLength(TaskNameLengthMin)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [Required]
        [Range(0, 4)]
        public int LabelType { get; set; }
    }
}
