using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryKitColors { get; set; }

        public virtual ICollection<Team> SecondaryKitColors { get; set; }
    }
}
