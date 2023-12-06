using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportXmlMedicineDto
    {
        [Required]
        [MinLength(MedicineNameLengthMin)]
        [MaxLength(MedicineNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)MedicinePriceRangeMin, (double)MedicinePriceRangeMax)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Required]
        [XmlAttribute("category")]
        [Range(0, 4)]
        public int Category { get; set; }

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; } = null!;

        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [MinLength(MedicineProducerLengthMin)]
        [MaxLength(MedicineProducerLengthMax)]
        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;
    }
}
