using System.ComponentModel.DataAnnotations;
using static Footballers.Utilities.GlobalConstants;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team() 
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TeamNameLengthMax)]
        [RegularExpression(TeamNameRegularExpressionValidation)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(TeamNationalityLengthMax)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
