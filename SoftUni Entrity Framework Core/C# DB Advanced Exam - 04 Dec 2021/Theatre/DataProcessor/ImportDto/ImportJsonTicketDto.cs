using System.ComponentModel.DataAnnotations;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportJsonTicketDto
    {
        [Required]
        [Range((double)TicketPriceMin, (double)TicketPriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Range(TicketRowNumberMin, TicketRowNumberMax)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
