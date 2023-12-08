using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play() 
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PlayTitleLengthMax)]
        public string Title { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(PlayRatingMin, PlayRatingMax)]
        public float Rating { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [StringLength(PlayDescriptionLengthMax)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(PlayScreenwriterLengthMax)]
        public string Screenwriter { get; set; } = null!;

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
