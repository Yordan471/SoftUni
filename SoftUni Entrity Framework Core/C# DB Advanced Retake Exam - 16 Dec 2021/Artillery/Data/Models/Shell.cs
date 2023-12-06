using System.ComponentModel.DataAnnotations;
using static Artillery.Utilities.GlobalConstants;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell() 
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(ShellWeightMin, ShellWeightMax)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(ShellCaliberLengthMax)]
        public string Caliber { get; set; } = null!;

        public ICollection<Gun> Guns { get; set; }
    }
}
