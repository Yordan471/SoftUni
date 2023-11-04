using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}