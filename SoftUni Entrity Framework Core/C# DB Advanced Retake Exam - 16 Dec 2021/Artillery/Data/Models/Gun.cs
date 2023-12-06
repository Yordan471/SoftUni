using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun() 
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        [Range(GunWeightMin, GunWeightMax)]
        public int GunWeight { get; set; }

        [Required]
        [Range(GunBarrelLengthMin, GunBarrelLengthMax)]
        public double BarrelLength { get; set; }

        public int NumberBuild { get; set; }

        [Required]
        [Range(GunRangeMin, GunRangeMax)]
        public int Range { get; set; }

        [Required]
        [Range(0, 5)]
        public GunType GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        [ForeignKey(nameof(ShellId))]
        public Shell Shell { get; set; } = null!;

        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
