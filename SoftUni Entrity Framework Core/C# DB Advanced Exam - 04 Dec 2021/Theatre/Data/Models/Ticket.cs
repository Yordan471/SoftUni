using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range((double)TicketPriceMin, (double)TicketPriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Range(TicketRowNumberMin, TicketRowNumberMax)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }

        [ForeignKey(nameof(PlayId))]
        public virtual Play Play { get; set; } = null!;

        [Required]
        public int TheatreId { get; set; }

        [ForeignKey(nameof(TheatreId))]
        public virtual Theatre Theatre { get; set; } = null!;
    }
}
