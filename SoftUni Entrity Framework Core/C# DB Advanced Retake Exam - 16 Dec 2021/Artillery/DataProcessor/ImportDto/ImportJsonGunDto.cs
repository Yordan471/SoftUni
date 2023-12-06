using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportJsonGunDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(GunWeightMin, GunWeightMax)]
        public int GunWeight { get; set; }

        [Required]
        [Range(GunBarrelLengthMin, GunBarrelLengthMax)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(GunRangeMin, GunRangeMax)]
        public int Range { get; set; }

        [Required]
        [Range(0, 5)]
        public string GunType { get; set; } = null!;

        public int[] Countries { get; set; }
    }
}
