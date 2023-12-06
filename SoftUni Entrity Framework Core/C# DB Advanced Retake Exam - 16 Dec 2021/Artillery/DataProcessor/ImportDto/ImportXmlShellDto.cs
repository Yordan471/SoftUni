using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportXmlShellDto
    {
        [Required]
        [Range(ShellWeightMin, ShellWeightMax)]
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(ShellCaliberLengthMax)]
        [MinLength(ShellCaliberLengthMin)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; } = null!;
    }
}
