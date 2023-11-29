using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models;
using static Trucks.Utilities.GlobalConstants;


namespace Trucks.DataProcessor.ImportDto
{
    public class ImportJsonClientDto
    {
        [Required]
        [MinLength(ClientNameLengthMin)]
        [MaxLength(ClientNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ClientNationalityLengthMin)]
        [MaxLength(ClientNationalityLengthMax)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public int[] Trucks { get; set; }
    }
}
