using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;
using static Trucks.Utilities.GlobalConstants;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportXmlTruckDto
    {
        [Required]
        [RegularExpression(TruckRegistrationNumberRegexValidation)]
        [XmlElement("RegistrationNumber")]
        public string? RegistrationNumber { get; set; }

        [Required]
        [MinLength(TruckVitNumberLength)]
        [MaxLength(TruckVitNumberLength)]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;


        [Range(TruckTankCapacityMin, TruckTankCapacityMax)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }


        [Range(TruckCargoCapacityMin, TruckCargoCapacityMax)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}
