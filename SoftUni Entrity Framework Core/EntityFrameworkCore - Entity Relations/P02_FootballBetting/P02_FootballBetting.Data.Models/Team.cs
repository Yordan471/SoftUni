using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string LogoURL { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        [ForeignKey(nameof(PrimaryKitColor))]
        public virtual Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        [ForeignKey(nameof(SecondaryKitColor))]
        public virtual Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        [ForeignKey(nameof(TownId))]
        public virtual Town Town { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }
    }
}
