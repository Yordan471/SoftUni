using System.ComponentModel.DataAnnotations;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportJsonTheatreDto
    {
        [Required]
        [MaxLength(TheatreNameLengthMax)]
        [MinLength(TheatreNameLengthMin)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(TheatreNumberOfHallsMin, TheatreNumberOfHallsMax)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(TheatreDirectorLengthMax)]
        [MinLength(TheatreDirectorLengthMin)]
        public string Director { get; set; } = null!;

        public ImportJsonTicketDto[] Tickets { get; set; }
    }
}
