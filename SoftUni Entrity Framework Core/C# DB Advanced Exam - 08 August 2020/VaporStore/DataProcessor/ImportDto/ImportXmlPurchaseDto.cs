using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportXmlPurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; } = null!;

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        [XmlElement("Key")]
        public string ProductKey { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [XmlElement("Card")]
        public string Card { get; set; } = null!;

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; } = null!;
    }
}
