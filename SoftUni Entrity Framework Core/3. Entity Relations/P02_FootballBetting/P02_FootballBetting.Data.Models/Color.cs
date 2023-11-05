using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
