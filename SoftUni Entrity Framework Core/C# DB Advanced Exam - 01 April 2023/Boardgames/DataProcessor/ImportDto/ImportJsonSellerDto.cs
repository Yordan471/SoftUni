using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportJsonSellerDto
    {
        [Required]
        [MinLength(SellarNameLengthMin)]
        [MaxLength(SellarNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(SellarAddressLengthMin)]
        [MaxLength(SellarAddressLengthMax)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;

        public int[] Boardgames { get; set; } = null!;
    }
}
