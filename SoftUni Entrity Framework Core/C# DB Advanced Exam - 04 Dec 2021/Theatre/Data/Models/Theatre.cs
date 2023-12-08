using System.ComponentModel.DataAnnotations;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre() 
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TheatreNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(TheatreNumberOfHallsMin, TheatreNumberOfHallsMax)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(TheatreDirectorLengthMax)]
        public string Director { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
