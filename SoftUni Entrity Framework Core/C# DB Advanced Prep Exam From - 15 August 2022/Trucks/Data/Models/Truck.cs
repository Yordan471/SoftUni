using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;
using static Trucks.Utilities.GlobalConstants;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck() 
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [RegularExpression(TruckRegistrationNumberRegexValidation)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [StringLength(TruckVitNumberLength)]
        public string VinNumber { get; set; } = null!;

        [Range(TruckTankCapacityMin, TruckTankCapacityMax)]
        public int TankCapacity { get; set; }

        [Range(TruckCargoCapacityMin, TruckCargoCapacityMax)]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0, 3)]
        public CategoryType CategoryType { get; set; }

        [Required]
        [Range(0, 4)]
        public MakeType MakeType { get; set; }

        [Required]
        public int DespatcherId { get; set; }

        [ForeignKey(nameof(DespatcherId))]
        public Despatcher Despatcher { get; set; } = null!;

        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
