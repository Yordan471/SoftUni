using System.ComponentModel.DataAnnotations;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country() 
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CountryNameLengthMax)]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(CountryArmySizeMin, CountryArmySizeMax)]
        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
