using System.ComponentModel.DataAnnotations;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer() 
        {
            Guns = new HashSet<Gun>();
        }   

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ManufacturerNameLengthMax)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [StringLength(ManufacturerFoundedLengthMax)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
